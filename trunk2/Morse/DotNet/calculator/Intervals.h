#pragma once

#include <math.h>


#include "./boost/numeric/interval.hpp"


struct my_arith_rounding:
  boost::numeric::interval_lib::rounded_arith_opp<double>
{
  double int_down(double f) { return floor(f); }
  double int_up  (double f) { return ceil(f); }
};

typedef boost::numeric::interval<
  double,
  boost::numeric::interval_lib::policies<
    boost::numeric::interval_lib::save_state<
      boost::numeric::interval_lib::rounded_transc_std<
        double,
        my_arith_rounding > >,
    boost::numeric::interval_lib::checking_strict<double> >
  > 
 Interval;



/*
typedef boost::numeric::interval<
		double, 
		boost::numeric::interval_lib::policies<		
			boost::numeric::interval_lib::save_state<
				boost::numeric::interval_lib::rounded_transc_exact<double, 
					boost::numeric::interval_lib::rounded_arith_opp<double> 
				> 
			>,
			boost::numeric::interval_lib::checking_strict<double> 
			//boost::numeric::interval_lib::checking_base<double>
		>
	> Interval;
*/