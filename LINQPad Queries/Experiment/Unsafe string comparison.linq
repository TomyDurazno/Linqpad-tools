<Query Kind="Program" />

void Main()
{
	LoopBodyLayout().Dump();
}

public bool LoopBodyLayout() => StringsAreEqual(
    "this is a test to see if these strings are equal",
    "this is a test to see if these strings are equal");

private unsafe bool StringsAreEqual(string strA, string strB)
{
    int length = strA.Length;

    fixed (char* ap = strA, bp = strB)
    {
        char* a = ap;
        char* b = bp;
		
        while (length != 0)
        {
            int charA = *a;
            int charB = *b;

            if (charA != charB)
            {
                return false;
            }

            a++;
            b++;
            length--;
        }

        return true;
    }
}
