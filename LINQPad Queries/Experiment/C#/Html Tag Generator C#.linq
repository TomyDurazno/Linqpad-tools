<Query Kind="Program" />

void Main()
{	
	var tas = new Tagger("select", new { @class = "form-control chosen-select", multiple ="multiple", data_placeholder = "Miembros del grupo", id = "ddlTest" });	
	
	var opcions = new Dictionary<string, string>();
	
	opcions.Add("1","AAA");
	opcions.Add("2","BBB");
	opcions.Add("3","CCC");
	opcions.Add("4","DDD");
	
	var opc = opcions
		.Select( o => new Tagger("option", 
			new {value = o.Key}).addHTML(o.Value).ToString())
		.Aggregate( (t1,t2) => t1 + t2);
		
	tas.addHTML(opc).ToString().Dump();	
}

public class Tagger
{
	public string innerHTML {get; set;}
	private string tag {get; set;}
	private object htmlAttr {get; set;}
	
	public Tagger(string tag, object htmlAttr = null)
	{
		this.tag = tag;
		this.htmlAttr = htmlAttr;
	}
	
	public override string ToString()
	{
		IEnumerable<string> attr = null;
		
		if(htmlAttr != null){
			attr = htmlAttr
				.GetType()
				.GetProperties()
				.Select(g =>{
					return string.Format(" {0}='{1}'",
					g.Name.ToLower().Replace("_","-"),
					g.GetValue(htmlAttr).ToString());
				});
		}else{
			attr = new List<string>();
		}		
	
		return string.Format("<{0} {1}>{2}</{0}>", tag, string.Join(" ", attr), innerHTML);	
	}
	
	public Tagger addHTML(string html){
		
		innerHTML += html;
		return this;
	}
}