#include "StdAfx.h"
#include ".\functionfactoryparseexception.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionFactoryParseException::FunctionFactoryParseException(FunctionFactoryParseExceptionType type, const char* problem) : type(type)
{
	char tmp[30];
	for (int i=0; i<25 && *problem != 0; i++) {
		tmp[i] = *problem++;
	}
	tmp[i++] = '\0';

	switch (type) {
		case FunctionFactoryParseException_BracketExpected:
			sprintf(buff, "Bracket Expected: \n '%s'", tmp);
			break;
		case FunctionFactoryParseException_DiffUnImplemented:
			sprintf(buff, "Unable to perform differentiation");
			break;
		case FunctionFactoryParseException_EqualsExpected:
			sprintf(buff, "Equals sign Expected: \n '%s'", tmp);
			break;
		case FunctionFactoryParseException_FormulaEndExpected:
			sprintf(buff, "Missing Formula end sign (';'):\n '%s'", tmp);
			break;
		case FunctionFactoryParseException_IndeferExpected:
			sprintf(buff, "Missing Indefer:\n '%s'", tmp);
			break;
		case FunctionFactoryParseException_Native_UnableToCompileNode:
			sprintf(buff, "Unable to Compile to Native\nSwotch of this feature");
			break;
		case FunctionFactoryParseException_Native_VariableNotDefined:
			sprintf(buff, "Equation depends on unintroduced variable");
			break;
		case FunctionFactoryParseException_NoSuchEquation:
			sprintf(buff, "Equation not found");
			break;
		case FunctionFactoryParseException_RecursiveDefinition:
			sprintf(buff, "Recursive definition. Unable to resolve");
			break;
		case FunctionFactoryParseException_SemicolumnExpected:
			sprintf(buff, "Comma Expected:\n '%s'", tmp);
			break;
		case FunctionFactoryParseException_WrongParamCount:
			sprintf(buff, "Wrong number of perameters", tmp);
			break;
		default:
			sprintf(buff,"Unknown exception");
			break;
	}
}

FunctionFactoryParseException::FunctionFactoryParseException(const FunctionFactoryParseException& ex) {
	strcpy(buff, ex.getMessage());
	type = ex.type;
}

FunctionFactoryParseException& FunctionFactoryParseException::operator =(const FunctionFactoryParseException& ex) {
	strcpy(buff, ex.getMessage());
	type = ex.type;
	return *this;
}

FunctionFactoryParseException::~FunctionFactoryParseException(void)
{
}


const char* FunctionFactoryParseException::getMessage() const{
	return buff;
}

FunctionFactoryParseExceptionType FunctionFactoryParseException::getType() {
	return type;
}
