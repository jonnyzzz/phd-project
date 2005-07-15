#include "StdAfx.h"
#include ".\intervalvalue.h"

const IntervalValue::ZERO = IntervalValue(0);

IntervalValue::IntervalValue(void)
{
	left = right = 0;
}

IntervalValue::IntervalValue(const IntervalValue& value) {
	left = value.left;
	right = value.right;
}

IntervalValue::IntervalValue(const double& left, const double& right) {
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

IntervalValue IntervalValue::operator +(const IntervalValue& value) const {	
	return IntervalValue(left - value.right, right -  value.left);	
}

IntervalValue IntervalValue::operator *(const IntervalValue& value) const {
	if (value >= ZERO) {
		if (&this >= ZERO) {
			return IntervalValue(left*value.left, right*value.right);
		} else if (this->Contatins(0)) {
			return IntervalValue(left*value.right, right*value.right);
		} else if (&this <= ZERO) {
			return IntervalValue(left*value.right, right*value.left);
		}
	} else if (value.Contatins(ZERO)) {
		if (&this >= ZERO) {
			return IntervalValue(left*value.right, right*value.right);
		} else if (this->Contatins(0)) {
			return IntervalValue(min(left*value.right, right*value.left), max(left*value.left, right*value.right));
		} else if (&this <= ZERO) {
			return IntervalValue(left*value.right, left*value.left);
		}
	} else if (value <= ZERO) {
		if (&this >= ZERO) {
			return IntervalValue(right*value.left, left*value.right);
		} else if (this->Contatins(0)) {
			return IntervalValue(right*value.left, left*value.left);			
		} else if (&this <= ZERO) {
			return IntervalValue(right*value.right, left*value.left);
		}
	}
	ASSERT(false);
	return ZERO;
}



double IntervalValue::min(const double& x, const double& y) {
	return (x<y)?x:y;
}

double IntervalValue::max(const double& x, const double& y) {
	return (x>y)?x:y;
}