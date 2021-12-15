#include <windows.h>
#include <tlhelp32.h>
#include <tchar.h>

BOOL GetProcessList();
BOOL ListProcessModules(DWORD dwPID);
BOOL ListProcessThreads(DWORD dwOwnerPID);

int main()
{
	GetProcessList();
	system("pause");
	return 0;
}

BOOL GetProcessList()
{
	HANDLE hProcessSnap; //дискриптор объекта
	HANDLE hProcess;
	PROCESSENTRY32 pe32; //вход в список процессов
	DWORD dwPriorityClass; //unsigned int

	hProcessSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	//Cоздает снапшот запущенных процессов, модулей и т.д.
	//Аргумент dwFlags определяет, снапшот чего именно мы хотим получить. 
	//Параметр dwProcessId задает идентификатор процесса, для которого создается снапшот. 
	//Возвращает хэндл снапшота

	if (hProcessSnap == INVALID_HANDLE_VALUE)
	{
		return(FALSE);
	}

	pe32.dwSize = sizeof(PROCESSENTRY32); //возвращает количество памяти, которую занимает processentry32

	if (!Process32First(hProcessSnap, &pe32))
	{
		CloseHandle(hProcessSnap);
		return(FALSE);
	}
	//Process32First принимает хэндл, полученный от CreateToolhelp32Snapshot, 
	//вызванной с dwFlags = TH32CS_SNAPPROCESS, а также указатель на структуру PROCESSENTRY32. 
	//Перед вызовом процедуры поле dwSize этой структуры должно быть установлено в sizeof(PROCESSENTRY32). 
	//В случае успеха возвращается TRUE, а в peProcessEntry записывается информация о первом процессе

	do
	{
		_tprintf(TEXT("\nPROCESS NAME:  %s"), pe32.szExeFile);

		dwPriorityClass = 0;
		hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, pe32.th32ProcessID);
		dwPriorityClass = GetPriorityClass(hProcess);
		CloseHandle(hProcess);

		_tprintf(TEXT("\n  Process ID        = 0x%08X"), pe32.th32ProcessID);
		_tprintf(TEXT("\n  Thread count      = %d"), pe32.cntThreads);
		_tprintf(TEXT("\n  Parent process ID = 0x%08X"), pe32.th32ParentProcessID);
		_tprintf(TEXT("\n  Priority base     = %d"), pe32.pcPriClassBase);

		ListProcessModules(pe32.th32ProcessID);
		ListProcessThreads(pe32.th32ProcessID);

	} while (Process32Next(hProcessSnap, &pe32)); //то же самое, что и Process32First, только для следующих
	CloseHandle(hProcessSnap);
	return(TRUE);
}

BOOL ListProcessModules(DWORD dwPID)
{
	HANDLE hModuleSnap = INVALID_HANDLE_VALUE;
	MODULEENTRY32 me32; //служит для перечисления модулей в заданном процессе

	hModuleSnap = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE, dwPID);
	if (hModuleSnap == INVALID_HANDLE_VALUE)
	{
		return(FALSE);
	}

	me32.dwSize = sizeof(MODULEENTRY32);

	if (!Module32First(hModuleSnap, &me32))
	{
		CloseHandle(hModuleSnap);
		return(FALSE);
	}
	do
	{
		_tprintf(TEXT("\n\n     MODULE NAME:     %s"), me32.szModule);
		_tprintf(TEXT("\n     Path     = %s"), me32.szExePath);
		_tprintf(TEXT("\n     Process ID     = 0x%08X"), me32.th32ProcessID);
		_tprintf(TEXT("\n     Base size      = %d"), me32.modBaseSize);

	} while (Module32Next(hModuleSnap, &me32));
	CloseHandle(hModuleSnap);
	return(TRUE);
}

BOOL ListProcessThreads(DWORD dwOwnerPID)
{
	HANDLE hThreadSnap = INVALID_HANDLE_VALUE;
	THREADENTRY32 te32;

	hThreadSnap = CreateToolhelp32Snapshot(TH32CS_SNAPTHREAD, 0);
	if (hThreadSnap == INVALID_HANDLE_VALUE)
		return(FALSE);

	te32.dwSize = sizeof(THREADENTRY32);

	if (!Thread32First(hThreadSnap, &te32))
	{
		CloseHandle(hThreadSnap);
		return(FALSE);
	}
	do
	{
		if (te32.th32OwnerProcessID == dwOwnerPID)
		{
			_tprintf(TEXT("\n\n     THREAD ID      = 0x%08X"), te32.th32ThreadID);
			_tprintf(TEXT("\n     Base priority  = %d"), te32.tpBasePri);
			_tprintf(TEXT("\n     Delta priority = %d"), te32.tpDeltaPri);
			_tprintf(TEXT("\n"));
		}
	} while (Thread32Next(hThreadSnap, &te32));
	CloseHandle(hThreadSnap);
	return(TRUE);
}