#
# Makefile for the Duwamish 7.0 Sample Application, BusinessRules Assembly
#

#
# Include Shared definitions
#
!include ..\..\shared.mak

#
# The target Assembly
#
TARGET=..\..\$(WEBDIR)\bin\Duwamish7.BusinessRules.dll

#
# Referenced Assemblies
#
REFERENCES= \
	-r:System.dll \
	-r:System.Data.dll \
	-r:System.Xml.dll \
	-r:..\..\$(WEBDIR)\bin\Duwamish7.SystemFramework.dll \
	-r:..\..\$(WEBDIR)\bin\Duwamish7.Common.dll \
	-r:..\..\$(WEBDIR)\bin\Duwamish7.DataAccess.dll

#
# The Sources
#
SOURCES= \
	AssemblyInfo.vb \
	Customer.vb \
	Order.vb

#
# Everything
#
all	: $(TARGET)
	

$(TARGET) : $(SOURCES)
	vbc.exe $(VBCOPTS) -target:library $(REFERENCES) $(SOURCES) -out:$(TARGET)
