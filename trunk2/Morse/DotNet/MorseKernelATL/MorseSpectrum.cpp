// MorseSpectrum.cpp : Implementation of CMorseSpectrum

#include "stdafx.h"
#include "MorseSpectrum.h"
#include ".\morsespectrum.h"


// CMorseSpectrum


HRESULT CMorseSpectrum::FinalConstruct() {

	TRACE_CREATE(CMorseSpectrum);

	return S_OK;
}


void CMorseSpectrum::FinalRelease() {
	TRACE_DESTRUCT(CMorseSpectrum);
}



STDMETHODIMP CMorseSpectrum::get_lowerBound(DOUBLE* pVal)
{
	*pVal = upper;

	return S_OK;
}

STDMETHODIMP CMorseSpectrum::put_lowerBound(DOUBLE pVal)
{
	lower = pVal;

	return S_OK;
}

STDMETHODIMP CMorseSpectrum::get_upperBound(DOUBLE* pVal)
{
	*pVal = upper;

	return S_OK;
}

STDMETHODIMP CMorseSpectrum::put_upperBound(DOUBLE pVal){
	
	upper = pVal;

	return S_OK;
}

STDMETHODIMP CMorseSpectrum::get_lowerLength(LONG* pVal)
{
	*pVal = lowerLength;

	return S_OK;
}

STDMETHODIMP CMorseSpectrum::put_lowerLength(LONG newVal)
{
	lowerLength = newVal;

	return S_OK;
}

STDMETHODIMP CMorseSpectrum::get_upperLength(LONG* pVal)
{
	*pVal = upperLength;

	return S_OK;
}

STDMETHODIMP CMorseSpectrum::put_upperLength(LONG newVal)
{
	upperLength = newVal;

	return S_OK;
}
