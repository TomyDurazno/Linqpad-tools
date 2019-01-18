<Query Kind="VBProgram" />

Sub Main
	ThisIsATest().Dump()
End Sub

Public Function ThisIsATest() As XElement
    Return <root>
                <child>this is some XML</child>
              </root>
End Function
