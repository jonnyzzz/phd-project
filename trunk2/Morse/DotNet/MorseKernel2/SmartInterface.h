#pragma once

template<class I = IUnknown>
class SmartInterface
{
private:
	I* data;

public:
	SmartInterface(I* data = NULL) {
		this->data = data;	
	}

	SmartInterface(const SmartInterface<I>& interf) {		
		interf.data->QueryInterface(&this->data);
	}

	~SmartInterface(void) {
		SAFE_RELEASE(data);
	}

public:
	I* operator ->() {
		return data;
	}

	I** operator &() {
		return &data;
	}

	bool operator != ( I* val) const {
		return this->data != val;
	}

	operator I*& () {
		return data;
	}

	template <class J>
	SmartInterface<I>& operator = (const SmartInterface<J>& interf) {		
		SAFE_RELEASE(data);
		interf.data->QueryInterface(&this->data);
	}

};
