#pragma once

class FunctionDictionary
{
public:
	FunctionDictionary(void);
	~FunctionDictionary(void);

public:
	int registerVariable(const char* name);
	const char* getName(int variableID);
	int lookUp(const char* name);

private:
	struct record {
		char* name;
		int id;
		record* next;
	};

	record* root;
	int maxID;

	char buff[255];

private:
	record* find(int id);
	record* find(const char* name);

	record* insert(const char* name);

};
