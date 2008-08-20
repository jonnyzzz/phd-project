#include "StdAfx.h"
#include ".\intervalvalue.h"

const IntervalValue IntervalValue::ZERO = IntervalValue(0);

IntervalValue::IntervalValue(void)
{
	left = right = 0;
}

IntervalValue::IntervalValue(const IntervalValue& value) {
	left = value.left;
	right = value.right;
}

/*
IntervalValue::IntervalValue(const double& left, const double& right) {
	this->left = left;
	this->right = right;
}
*/

IntervalValue::IntervalValue(double left, double right) {
	this->left = left;
	this->right = right;
}


IntervalValue::IntervalValue(const double& value) {
	left = right = value;
}

IntervalValue::~IntervalValue(void)
{
}


double IntervalValue::Left() const {
	return left;
}

double IntervalValue::Right() const {
	return right;
}

bool IntervalValue::IsNaN() const {
	//todo:
	return false;
}

bool IntervalValue::Contatins(const double& x) const {
	return left <= x && x <= right;
}

bool IntervalValue::operator >=(const IntervalValue& value) const {
	return (left >= value.right);
}
bool IntervalValue::operator <=(const IntervalValue& value) const {
	return (right <= value.left);
}
bool IntervalValue::operator ==(const IntervalValue& value) const {
	return (left == value.left && right == value.right);
}

IntervalValue IntervalValue::operator +(const IntervalValue& value) const {
	return IntervalValue(left+value.left, right +  value.right);
}

IntervalValue IntervalValue::operator -(const IntervalValue& value) const {	
	return IntervalValue(left - value.right, right -  value.left);	
}

IntervalValue IntervalValue::operator *(const IntervalValue& value) const {
	if (value >= ZERO) {
		if (*this >= ZERO) {
			return IntervalValue(left*value.left, right*value.right);
		} else if (this->Contatins(0)) {
			return IntervalValue(left*value.right, right*value.right);
		} else if (*this <= ZERO) {
			return IntervalValue(left*value.right, right*value.left);
		}
	} else if (value.Contatins(0)) {
		if (*this >= ZERO) {
			return IntervalValue(left*value.right, right*value.right);
		} else if (this->Contatins(0)) {
			return IntervalValue(				
				this->min(left*value.right, right*value.left), 
				this->max(left*value.left, right*value.right)
			);
		} else if (*this <= ZERO) {
			return IntervalValue(left*value.right, left*value.left);
		}
	} else if (value <= ZERO) {
		if (*this >= ZERO) {
			return IntervalValue(right*value.left, left*value.right);
		} else if (this->Contatins(0)) {
			return IntervalValue(right*value.left, left*value.left);			
		} else if (*this <= ZERO) {
			return IntervalValue(right*value.right, left*value.left);
		}
	}
	ASSERT(false);
	return ZERO;
}

IntervalValue IntervalValue::operator /(const IntervalValue& value) const {
	if (value >= 0) {
		if (*this >= ZERO) {
			return IntervalValue(left/value.right, right*value.left);
		} else if (this->Contatins(0)) {
			return IntervalValue(left*value.left, right*value.left);	
		} else if (*this <= ZERO) {
			return IntervalValue(left*value.left, right*value.right);
		}
	}else {
		if (*this >= ZERO) {
			return IntervalValue(right*value.right, left*value.left);
		} else if (this->Contatins(0)) {
			return IntervalValue(right*value.right, left*value.right);			
		} else if (*this <= ZERO) {
			return IntervalValue(right*value.left, left*value.right);
		}
	}
	ASSERT(false);
	return ZERO;
}


double IntervalValue::min(double x, double y) const {
	return (x<y)?x:y;
}

double IntervalValue::max(double x, double y) const {
	return (x>y)?x:y;
}

using namespace std;
void IntervalValue::print(ostream& o) {
	o << "["<<left<<", "<<right<<" ] ";
}