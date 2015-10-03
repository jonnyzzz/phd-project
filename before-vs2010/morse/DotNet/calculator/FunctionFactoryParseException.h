#pragma once

enum FunctionFactoryParseExceptionType {
	FunctionFactoryParseException_IndeferExpected,
	FunctionFactoryParseException_EqualsExpected,
	FunctionFactoryParseException_BracketExpected,
	FunctionFactoryParseException_SemicolumnExpected,
	FunctionFactoryParseException_FormulaEndExpected,
	FunctionFactoryParseException_NoSuchEquation,
	FunctionFactoryParseException_RecursiveDefinition,
	FunctionFactoryParseException_WrongParamCount,
	FunctionFactoryParseException_DiffUnImplemented,
	FunctionFactoryParseException_Native_VariableNotDefined,
	FunctionFactoryParseException_Native_UnableToCompileNode,
};

class FunctionFactoryParseException
{
public:
	FunctionFactoryParseException(FunctionFactoryParseExceptionType type, const char* problem = "");
	~FunctionFactoryParseException(void);

public:
	FunctionFactoryParseException(const FunctionFactoryParseException& ex);
	FunctionFactoryParseException& operator =(const FunctionFactoryParseException& ex);

public:
	const char* getMessage() const;
	FunctionFactoryParseExceptionType getType();


private:
	char buff[1024];

	FunctionFactoryParseExceptionType type;

};
