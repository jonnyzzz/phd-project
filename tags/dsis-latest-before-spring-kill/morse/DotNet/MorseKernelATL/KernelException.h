#pragma once


enum KernelExceptionType {
	KernelException_NoDimention,
	KernelException_NegativeDimention,
	KernelException_NoSpaceMax,
	KernelException_NoSpaceMin,
	KernelException_NegativeSpace,
	KernelException_NoGrid,
	KernelException_NegativeGrid,

	KernelException_UnableToEvaluateDimension,
	KernelException_UnableToEvaluateSpaceMin,
	KernelException_UnableToEvaluateSpaceMax,
	KernelException_UnableToEvaluateGrid,
	KernelException_UnexpectedVariableDependency,

	KernelException_NoFunctionFactory,
	KernelException_NoFunctionEquation,
	KernelException_WrongIterations,

	KernelException_Unknown,
};

class FunctionFactoryParseException;
class GraphException;


class KernelException
{
public:
	KernelException(KernelExceptionType type = KernelException_Unknown, int value=0);
	KernelException(const FunctionFactoryParseException& pex);
	KernelException(const GraphException& gex);
	
	~KernelException(void);

public:
	CString getMessage() const;

private:
	CString message;
};
