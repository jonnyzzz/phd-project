#pragma once


#include "./boost/numeric/interval.hpp"

typedef boost::numeric::interval<
		double, 
		boost::numeric::interval_lib::policies<		
			boost::numeric::interval_lib::save_state<
				boost::numeric::interval_lib::rounded_transc_std<double, 
					boost::numeric::interval_lib::rounded_arith_opp<double> 
				> 
			>,
			boost::numeric::interval_lib::checking_strict<double> 
		>
	> Interval;


