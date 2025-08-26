#include "pch.h"
#include <tchar.h>
#include <iostream>

extern "C" {

    class __declspec(dllexport) CompExtended1S {
    public:
        TCHAR CPU[250];
        int RAM;
        double Cost;
        TCHAR GPU[250];

        CompExtended1S() {
            _tcscpy_s(this->CPU, _T(""));
            this->RAM = 0;
            this->Cost = 0.0;
            _tcscpy_s(this->GPU, _T(""));
        }

        ~CompExtended1S() {}

        void InputCompExtended1() {
            _tprintf(_T("Enter CPU: "));
            _tscanf_s(_T("%s"), this->CPU, (unsigned)_countof(this->CPU));

            _tprintf(_T("Enter RAM: "));
            std::cin >> this->RAM;

            _tprintf(_T("Enter Cost: "));
            std::cin >> this->Cost;

            _tprintf(_T("Enter GPU: "));
            _tscanf_s(_T("%s"), this->GPU, (unsigned)_countof(this->GPU));
        }

        void OutputCompExtended1() {
            _tprintf(_T("CPU: %s\n"), this->CPU);
            _tprintf(_T("RAM: %d\n"), this->RAM);
            _tprintf(_T("Cost: %f\n"), this->Cost);
            _tprintf(_T("GPU: %s\n"), this->GPU);
        }
    };

    class __declspec(dllexport) CompExtended2S : public CompExtended1S {
    public:
        TCHAR Brand[250];

        CompExtended2S() : CompExtended1S() {
            _tcscpy_s(this->Brand, _T(""));
        }
        ~CompExtended2S() {}

        void InputCompExtended2() {
            InputCompExtended1();
            std::cin.ignore(std::cin.rdbuf()->in_avail());
            _tprintf(_T("Enter Brand: "));
            _tscanf_s(_T("%s"), this->Brand, (unsigned)_countof(this->Brand));
        }

        void OutputCompExtended2() {
            OutputCompExtended1();
            std::cin.ignore(std::cin.rdbuf()->in_avail());
            _tprintf(_T("Brand: %s\n"), this->Brand);
        }
    };

    class __declspec(dllexport) CompExtended3S : public CompExtended2S {
    public:
        TCHAR AdditionalInfo[250];

        CompExtended3S() : CompExtended2S() {
            _tcscpy_s(this->AdditionalInfo, _T(""));
        }
        ~CompExtended3S() {}

        void InputCompExtended3() {
            InputCompExtended2();
            _tprintf(_T("Enter GPU: "));
            _tscanf_s(_T("%s"), this->AdditionalInfo, (unsigned)_countof(this->AdditionalInfo));
        }

        void OutputCompExtended3() {
            OutputCompExtended2();
            _tprintf(_T("AdditionalInfo: %s\n"), this->AdditionalInfo);
        }
    };

}

extern "C" {
    __declspec(dllexport) void PrintString(const char* str) {
        std::cout << str << std::endl;
    }

    __declspec(dllexport) void PrintInt(int num) {
        std::cout << num << std::endl;
    }

    __declspec(dllexport) void PrintDouble(double num) {
        std::cout << num << std::endl;
    }

    __declspec(dllexport) void ScanString(char* str, int size) {
        std::cin.getline(str, size);
    }

    __declspec(dllexport) void ScanInt(int* num) {
        std::cin >> *num;
    }

    __declspec(dllexport) void ScanDouble(double* num) {
        std::cin >> *num;
    }
}

BOOL APIENTRY DllMain(HMODULE hModule,
    DWORD  ul_reason_for_call,
    LPVOID lpReserved
)
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

