#pragma once


template <class P> class smartPointer {
private:
	P* p;
public:
	smartPointer(P* p) : p(p) {}
	~smartPointer() { 
		delete p;
	};

	smartPointer(const smartPointer& p) {
		this->p = sp.p;
		sp.p = NULL;
	}
public:
	P* operator ->() {
		return p;
	}

	operator P*() {
		return p;
	}

    operator P&() {
        return *p;
    }

	smartPointer& operator = (const smartPointer& sp) {
		this->p = sp.p;
		sp.p = NULL;
		return *this;
	}

	smartPointer& operator = ( P* p) {
		delete this->p;
		this->p = p;
		return *this;
	}
};

template < > class smartPointer<GraphComponents> {
private:
	GraphComponents* p;

	void destroy() {
		if (p == NULL) return;
		for (int i=0; i<p->length(); delete p->getAt(i++));
		delete p;
	}
public:
	smartPointer(GraphComponents* p) : p(p) {cout<<"\nMy impl\n";}
	~smartPointer() { 
		destroy();
	};

	smartPointer(const smartPointer& sp) {
		throw -1;;
	}

public:
	GraphComponents* operator ->() {
		return p;
	}

	operator GraphComponents*() {
		return p;
	}

    operator GraphComponents&() {
		return *p;
	}

	smartPointer& operator = (const smartPointer& sp) {
		throw -1;		
	}

	smartPointer& operator = ( GraphComponents* p) {
		destroy();
		this->p = p;
		return *this;
	}

};

typedef smartPointer<FunctionNode> sFunctionNode;