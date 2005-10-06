#-----Macros---------------------------------

CXX = gcc
CXXFLAGS = -x c++ -I.

#-----Suffix Rules---------------------------
# set up C++ suffixes and relationship between .cc and .o files
#
# .SUFFIXES: .cpp
#
# %.o: ->   $(CXX) $(CXXFLAGS) -c $<

#-----File Dependencies----------------------

SRC = AbstractBoxProcess.cpp \
	AbstractGraphCreator.cpp \
	AbstractPointBuilder.cpp \
	AbstractProcess.cpp     \
	AbstractProcessExt.cpp   \
	BuildersException.cpp     \
	GraphSet.cpp               \
	MS2DBoxProcess.cpp          \
	LoopsLocalizationProcess.cpp \
	MS2DCreationProcess.cpp       \
	MSCreationProcess.cpp          \
	MSOverlapedPointBuilder.cpp     \
	MSPointBuilder.cpp               \
	Processes.cpp                     \
	ProgressBarInfo.cpp                \
	ProjectionProcess.cpp               \
	SIOverlapedPointBuilder.cpp          \
	SIPointBuilder.cpp                    \
	SegmentProjectiveBundleMSCreationProcess.cpp\
	SimpleBoxProcess.cpp                         \
	TarjanProcess.cpp                             \
	stdafx.cpp                                    


OBJ = $(addsuffix .o, $(basename $(SRC)))

compile: ; $(CXX) $(CXXFLAGS) -c $(SRC)

#%.o : ;  $(CXX) $(CXXFLAGS) -c $*.cpp
#
#  $(CXX) $(CXXFLAGS) $% -o $@ -lm $(TLIB) -lg++
#
#TASK: $(OBJ)
#	 $(CXX) $(CXXFLAGS) -o $@ $(OBJ) -lm $(TLIB) -lg++
#
#usepix: $(OBJ)  ->   $(CXX) $(CXXFLAGS) -o $@ $(OBJ) -lm $(TLIB) -lg++
#
#-----Other stuff----------------------------
#depend:    ->   makedepend $(CXXFLAGS) -Y $(SRC)
#

ALL: $(OBJ)

clean: $(OBJ) 
	rm -f $(OBJ)

