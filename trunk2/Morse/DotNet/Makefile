
SRC_CELLIMAGEBUILDER = AbstractBoxProcess.cpp \
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
                TarjanProcess.cpp                            \
                StableLocalizationProcess.cpp
DIR_CELLIMAGEBUILDER = cellImageBuilders/

SRC_GRAPH = CoordinateSystem.cpp           \
            ExtendedMenoryManager.cpp       \
            FileStream.cpp  \
            Graph.cpp         \
            GraphComponents.cpp \
            GraphException.cpp                    \
            GraphUtil.cpp                          \
            MemoryManager.cpp                         \
            Stack.cpp                   \
            LoopIterator.cpp
DIR_GRAPH = graph/

SRC_GRAPH_SIMPLEX = Rom.cpp \
                    RomFunction2N.cpp \
                    SIRom.cpp 
DIR_GRAPH_SIMPLEX = graph_simplex/

SRC_SYSTEM_FUNCTION =  IMorseFunction.cpp \
                       IProjectiveExtensionInfo.cpp \
                       ISystemFunction.cpp \
                       ISystemFunctionDerivate.cpp \
                       MS2DAngleFunction.cpp \
                       MS2DAngleMorseFunction.cpp \
                       SermentProjectiveExtensionInfo.cpp \
                       SegmentProjectiveExtendedSystemFunction.cpp \
                       SegmentProjectiveExtensionMorseFunction.cpp 
DIR_SYSTEM_FUNCTION = SystemFunction/

SRC_CONSOLE_TOOL = ConsoleTool.cpp \
                   TorstenFunction.cpp \
                   Util.cpp \
                   FunctionBase.cpp \
		   LogisticsMap.cpp \
                   ParametrisedLogisticsMap.cpp

DIR_CONSOLE_TOOL = ConsoleTool/

SRC_SEGMENT_ITERATOR = SegmentIterator.cpp 
DIR_SEGMENT_ITERATOR = SegmentIterator/


SRC = $(addprefix $(DIR_CELLIMAGEBUILDER), $(SRC_CELLIMAGEBUILDER)) \
      $(addprefix $(DIR_GRAPH), $(SRC_GRAPH)) \
      $(addprefix $(DIR_GRAPH_SIMPLEX), $(SRC_GRAPH_SIMPLEX)) \
      $(addprefix $(DIR_SYSTEM_FUNCTION), $(SRC_SYSTEM_FUNCTION)) \
      $(addprefix $(DIR_CONSOLE_TOOL), $(SRC_CONSOLE_TOOL)) \
      $(addprefix $(DIR_SEGMENT_ITERATOR), $(SRC_SEGMENT_ITERATOR))

DIRS = $(DIR_CONSOLE_TOOL) $(DIR_SYSTEM_FUNCTION) $(DIR_GRAPH_SIMPLEX) \
       $(DIR_GRAPH) $(DIR_CELLIMAGEBUILDER) $(DIR_SEGMENT_ITERATOR)

OBJ = $(addsuffix .o, $(basename $(SRC)))

# CXX = gcc
# CXXFLAGS = -x c++ $(addprefix -I,$(DIRS)) -lstdc++ -lstdc
#
#
# task: $(OBJ)
#      $(CXX) $(CFLAGS) $(LDFLAGS) $(OBJ) -o bin/morse
#      @echo Make gqthread is complete.
#
# clean:; rm -f $(OBJ)





CC      = gcc
# CFLAGS = $(addprefix -I,$(DIRS))
# CPPFLAGS = -p 
# CPPFLAGS  += -D DEBUG -D ENABLE_TRACE -ggdb -Wall
OBJECTS = $(OBJ)
CPPFLAGS += -O2
LDFLAGS +=  -lstdc++ -lm -O2

all:  $(OBJECTS)
	$(CC) $(CFLAGS) $(LDFLAGS) $(OBJECTS) -o bin/msnew
	@echo Make is complete.
clean:
	rm -f $(OBJECTS)

