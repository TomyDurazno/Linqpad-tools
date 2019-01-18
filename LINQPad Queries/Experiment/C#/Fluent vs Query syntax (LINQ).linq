<Query Kind="Expression">
  <Connection>
    <ID>a8ef58d3-40b4-4326-9637-9ff07d38833e</ID>
    <Persist>true</Persist>
    <Server>liza.test.agcontrol.gob.ar</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAArV4cXE7S0E2+SJ/iTdr7KAAAAAACAAAAAAAQZgAAAAEAACAAAADX8j6drwBzZJHMYi7Cs2Qqymme/UjfVJA31/w+eKU0nwAAAAAOgAAAAAIAACAAAADQzrv5apYSgg7ERVQljBQ84WuYRY2YNNJOTLmv0iigjxAAAADmDNj+N13iT1+k2EctkulTQAAAAOpO5aiXlM1F0H1FzBj4RJoU+E47TniOO/zO/qJDX++9oEthV3+29WbOOId7R1CreMlMmt05y1cOTDv2dwIN5sg=</Password>
    <Database>LIZA</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from piso in Pisos where piso.Id< 100 orderby piso.Id select piso
//Pisos.Where(p=>p.Id<100).OrderBy(p=>p.Id).Select(p=>p)