<Query Kind="Program" />

void Main()
{
	    public JsonResult PruebaDropzone(string tipo, int id)
        {
            var myTipo = AppDomain.CurrentDomain.GetAssemblies()
                                  .Aggregate(new List<Assembly>(), (a, i) => { a.Add(i); return a; }).ToList()
                                  .Where(am => am.GetTypes().Any(t => t.FullName.ToLower().Contains(tipo.ToLower())))
                                  .Aggregate(new List<Type>(), (a, i) => { a.AddRange(i.GetTypes()); return a; }).ToList()
                                  .Where(tip => tip.Name.ToLower().Equals(tipo.ToLower())).FirstOrDefault();

            if (myTipo == null) { return Json(new { msj="No existe el Tipo" }, JsonRequestBehavior.AllowGet); }

            try
            {
                dynamic o = Activator.CreateInstance(myTipo);

                return GetEntidad(o, id);
            }
            catch (Exception ex)
            {
                return Json(new { Mensaje = "No se pudo generar el tipo especificado. Ex: "+ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private JsonResult GetEntidad<T>(T ent, int id) where T : Entidad
        {
            var servicio = DependencyResolver.Current.GetService<IServicio<T>>();
                       
            IEntidadConDropzone entidad = servicio.BuscarTodos().Where(f => f.Id == id).FirstOrDefault() as IEntidadConDropzone;

            var completa = entidad?.ListaArchivosCompleta();

            if (completa == null)
            {
                return Json(new { msj = "La entidad no existe o no posee archivos dropzone asociados" }, JsonRequestBehavior.AllowGet);
            }

            var requeridos = entidad.TraerTiposDropzone().Select(a => a.ToString());
            var archivos = (entidad.GetType().GetProperty("Archivos").GetValue(entidad) as List<Archivo>).Select(a => a.TipoArchivoDropzone.ToString());

            return Json(new { Tipo = entidad.GetType().Name.Split('_').First(), Lista_Completa = completa, Requeridos = requeridos.OrderBy(r => r), Archivos = archivos.OrderBy(r => r) }, JsonRequestBehavior.AllowGet);
        }
}

// Define other methods and classes here
