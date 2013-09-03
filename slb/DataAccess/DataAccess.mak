#
# Makefile for the Duwamish 7.0 Sample Application, DataAccess Assembly
#

#
# Include Shared definitions
#
!include ..\shared.mak

#
# The target Assembly
#
TARGET=..\$(WEBDIR)\bin\Duwamish7.DataAccess.dll

#
# Referenced Assemblies
#
REFERENCES= \
	-r:System.dll \
	-r:System.Data.dll \
	-r:System.Web.dll \
	-r:System.Xml.dll \
	-r:..\$(WEBDIR)\bin\Duwamish7.SystemFramework.dll \
	-r:..\$(WEBDIR)\bin\Duwamish7.Common.dll

#
# The Sources
#
SOURCES= \
	AssemblyInfo.vb \
	Books.vb \
	Categories.vb \
	Customers.vb \
	Orders.vb

#
# Everything
#
all	: $(TARGET)
	

$(TARGET) : $(SOURCES)
	vbc.exe $(VBCOPTS) -target:library $(REFERENCES) $(SOURCES) -out:$(TARGET)
