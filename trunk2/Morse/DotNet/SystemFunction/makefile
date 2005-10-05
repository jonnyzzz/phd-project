#-----Macros---------------------------------

CXX = gcc
CXXFLAGS = -x c++ -I .
OUT = gccbuild


#-----Suffix Rules---------------------------
# set up C++ suffixes and relationship between .cc and .o files

.SUFFIXES: .cpp

.cpp.o: ->   $(CXX) $(CXXFLAGS) -c $<

.cpp :  ->   $(CXX) $(CXXFLAGS) $< -o $@ -lm $(TLIB) -lg++

#-----File Dependencies----------------------



#-----File Dependencies----------------------

SRC =  IMorseFunction.cpp IProjectiveExtensionInfo.cpp ISystemFunction.cpp ISystemFunctionDerivate.cpp MS2DAngleFunction.cpp MS2DAngleMorseFunction.cpp SermentProjectiveExtensionInfo.cpp SegmentProjectiveExtendedSystemFunction.cpp SegmentProjectiveExtensionMorseFunction.cpp stdafx.cpp


OBJ = $(addsuffix .o, $(basename $(SRC)))

usepix: $(OBJ)  ->   $(CXX) $(CXXFLAGS) -o $@ $(OBJ) -lm $(TLIB) -lg++

#-----Other stuff----------------------------
depend:    ->   makedepend $(CXXFLAGS) -Y $(SRC)

clean: $(OBJ) ->  rm -f $(OBJ)
