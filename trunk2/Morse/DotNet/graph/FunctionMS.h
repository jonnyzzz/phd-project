#pragma once

class Function;


class FunctionMS {
public:
	FunctionMS(Function* function);
	virtual ~FunctionMS();


public:
	JDouble* getVariables();
	
	JDouble Ro();


private:
	Function* function;
	JDouble* x;

private:
	JDouble sqr(JDouble x);
	JDouble Ro2();
	JDouble Ro3();
};