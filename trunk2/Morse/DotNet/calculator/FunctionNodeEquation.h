#pragma once

class FunctionNode;
class FunctionDictionary;

class FunctionNodeEquation
{
public:
	FunctionNodeEquation(int variableID, FunctionNode* root);
	virtual ~FunctionNodeEquation(void);

public:
	FunctionNode* getFunctionNode();
	int getVariableID();

	void print(ostream& o, FunctionDictionary* dic);

private:
	int variableID;
	FunctionNode* root;
};
