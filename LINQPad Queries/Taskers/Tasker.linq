<Query Kind="Program">
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

void Main()
{
    //Hint: posiblemente hay que hacer un form más bonito,
    //ver si se puede hacer en LinqPad. 
    var todo = Tasker.Do.Create;
        
    var ID = "ROC-347";    
    var Name = "Add element Ids";
        
    #region switch

    switch (todo)    
    {
        case Tasker.Do.Create:
        
            if(MessageBox.Show(string.Format("Desea crear la Task {0} con nombre: {1}?", ID, Name), "Crear Task", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Tasker.Create(ID, Name);
        
        break;

        case Tasker.Do.Move:
        
            if (MessageBox.Show(string.Format("Desea mover la Task {0} ?", ID), "Mover Task", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Tasker.Move(ID);
    
        break;
    }

    #endregion
}