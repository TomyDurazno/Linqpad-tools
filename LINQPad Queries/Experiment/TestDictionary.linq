<Query Kind="Program">
  <Connection>
    <ID>065ae213-6b0f-4f51-b433-7241b5c6b817</ID>
    <Persist>true</Persist>
    <Server>liza.desa.agcontrol.gob.ar</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAArV4cXE7S0E2+SJ/iTdr7KAAAAAACAAAAAAAQZgAAAAEAACAAAABSX27XDhzczS2QFgbR2eO0ufBDIWpp+p2tUz/18XDmJwAAAAAOgAAAAAIAACAAAAA4fyyqXVigqJ9p9kHfOPtIq4I65D77JznnP78ZP1kzkxAAAAChWNUfD7Z3sF80Bome6LQ+QAAAADeheret9AUVUsPONzzXFMvqNxM/JQlQPj6ddpJYqCLkFPYbtzp7aer2TVuEDjfHeVxpsIEKTzCoFcBAka5G/EM=</Password>
    <Database>LIZA</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	Guid.NewGuid().ToString().Split('-').First().Dump();
}

// Define other methods and classes here
