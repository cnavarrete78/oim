/*
 *******************************************************************************************
  PROGRAMA				: ArbolesPIRC.cs
  FECHA DE CREACION	    : 21-09-2018
  FECHA DE MODIFICACION : 
  VERSION               : 1.0
  AUTOR                 : OIM - Andrés Mauricio Bonilla Laguna

 *******************************************************************************************

  CLASE			        : ArbolesPIRC.cs
  RESPONSABILIDAD	    : Se encarga de manejar los datos de los arboles de la formulacion del PIRC
  COLABORACION		    : Ninguna
********************************************************************************************
*/

using System;
using System.Collections.Generic;

namespace com.GACV.lgb.modelo.arbolespirc
{
    // Persona
    public class ArbolProblemaED
    {
        private int ID_EFECTO_DIRECTO = 0;
        private string EFECTO_DIRECTO = "";

        private List<int> IDS_EID = new List<int>();
        private List<ArbolProblemaEID> EFECTOS_INDIRECTOS = new List<ArbolProblemaEID>();
        private System.Web.UI.WebControls.ListItemCollection CBL_EID = new System.Web.UI.WebControls.ListItemCollection();
       
        /// Método constructor de la clase       
        public ArbolProblemaED()
        {
        }

        #region Atributos de los efectos directos

        public int IdEfectoDirecto
        {
            get { return ID_EFECTO_DIRECTO; }
            set { ID_EFECTO_DIRECTO = value; }
        }
        public string EfectoDirecto
        {
            get { return EFECTO_DIRECTO; }
            set { EFECTO_DIRECTO = value; }
        }
        public List<int> IdsEID
        {
            get { return IDS_EID; }
            set { IDS_EID = value; }
        }
        public System.Web.UI.WebControls.ListItemCollection CblEID
        {
            get { return CBL_EID; }
            set { CBL_EID = value; }
        }
        public List<ArbolProblemaEID> FfectosIndirectos
        {
            get { return EFECTOS_INDIRECTOS; }
            set { EFECTOS_INDIRECTOS = value; }
        }

        #endregion
    }

    public class ArbolProblemaEID
    {
        private int ID_EFECTO_INDIRECTO = 0;
        private string EFETO_INDIRECTO = "";
        private List<int> IDS_ED = new List<int>();

        /// Método constructor de la clase       
        public ArbolProblemaEID()
        {
        }

        #region Atributos de los efectos indirectos

        public int IdEfectoIndirecto
        {
            get { return ID_EFECTO_INDIRECTO; }
            set { ID_EFECTO_INDIRECTO = value; }
        }
        public string EfectoIndirecto
        {
            get { return EFETO_INDIRECTO; }
            set { EFETO_INDIRECTO = value; }
        }

        public List<int> IdsED
        {
            get { return IDS_ED; }
            set { IDS_ED = value; }
        }

        #endregion
    }

    public class ArbolProblemaCD
    {
        private int ID_CATEGORIA_DANO = 0;
        private string CATEGORIA_DANO = "";

        private int ID_CAUSA_DIRECTA = 0;
        private string CAUSA_DIRECTA = "";

        private System.Web.UI.WebControls.ListItemCollection DDL_SCD = new System.Web.UI.WebControls.ListItemCollection();

        private List<ArbolProblemaSCD> LST_SCD = new List<ArbolProblemaSCD>();

        /// Método constructor de la clase       
        public ArbolProblemaCD()
        {
        }

        #region Atributos de las categorias de daño

        public int IdCategoriaDano
        {
            get { return ID_CATEGORIA_DANO; }
            set { ID_CATEGORIA_DANO = value; }
        }
        public string CategoriaDano
        {
            get { return CATEGORIA_DANO; }
            set { CATEGORIA_DANO = value; }
        }

        public int IdCausaDirecta
        {
            get { return ID_CAUSA_DIRECTA; }
            set { ID_CAUSA_DIRECTA = value; }
        }
        public string CausaDirecta
        {
            get { return CAUSA_DIRECTA; }
            set { CAUSA_DIRECTA = value; }
        }

        public List<ArbolProblemaSCD> LstSCD
        {
            get { return LST_SCD; }
            set { LST_SCD = value; }
        }
        public System.Web.UI.WebControls.ListItemCollection DdlSCD
        {
            get { return DDL_SCD; }
            set { DDL_SCD = value; }
        }

        #endregion
    }

    public class ArbolProblemaSCD
    {
        private int ID_SUBCATEGORIA_DANO = 0;
        private string SUBCATEGORIA_DANO = "";

        private System.Web.UI.WebControls.ListItemCollection CBL_CID = new System.Web.UI.WebControls.ListItemCollection();
        private List<ArbolProblemaCID> CAUSAS_INDIRECTAS = new List<ArbolProblemaCID>();

        /// Método constructor de la clase       
        public ArbolProblemaSCD()
        {
        }

        #region Atributos de las subcategorias de daño

        public int IdSubcategoriaDano
        {
            get { return ID_SUBCATEGORIA_DANO; }
            set { ID_SUBCATEGORIA_DANO = value; }
        }
        public string SubcategoriaDano
        {
            get { return SUBCATEGORIA_DANO; }
            set { SUBCATEGORIA_DANO = value; }
        }
        public System.Web.UI.WebControls.ListItemCollection CblCID
        {
            get { return CBL_CID; }
            set { CBL_CID = value; }
        }

        public List<ArbolProblemaCID> CausasIndirectas
        {
            get { return CAUSAS_INDIRECTAS; }
            set { CAUSAS_INDIRECTAS = value; }
        }

        #endregion
    }

    public class ArbolProblemaCID
    {
        private int ID_CAUSA_INDIRECTA = 0;
        private string CAUSA_INDIRECTA = "";

        /// Método constructor de la clase       
        public ArbolProblemaCID()
        {
        }

        #region Atributos de las causas indirectas

        public int IdCausaIndirecta
        {
            get { return ID_CAUSA_INDIRECTA; }
            set { ID_CAUSA_INDIRECTA = value; }
        }
        public string CausaIndirecta
        {
            get { return CAUSA_INDIRECTA; }
            set { CAUSA_INDIRECTA = value; }
        }

        #endregion
    }

    public class ArbolProblemaFD
    {
        private int ID_EFECTO_DIRECTO = 0;
        private string EFECTO_DIRECTO = "";

        private int ID_FIN_DIRECTO = 0;
        private string FIN_DIRECTO = "";

        private List<ArbolProblemaFID> LST_FID = new List<ArbolProblemaFID>();
        
        /// Método constructor de la clase       
        public ArbolProblemaFD()
        {
        }

        #region Atributos de los fines directos

        public int IdEfectoDirecto
        {
            get { return ID_EFECTO_DIRECTO; }
            set { ID_EFECTO_DIRECTO = value; }
        }
        public string EfectoDirecto
        {
            get { return EFECTO_DIRECTO; }
            set { EFECTO_DIRECTO = value; }
        }

        public int IdFinDirecto
        {
            get { return ID_FIN_DIRECTO; }
            set { ID_FIN_DIRECTO = value; }
        }
        public string FinDirecto
        {
            get { return FIN_DIRECTO; }
            set { FIN_DIRECTO = value; }
        }
        public List<ArbolProblemaFID> FinesIndirectos
        {
            get { return LST_FID; }
            set { LST_FID = value; }
        }
        #endregion
    }

    public class ArbolProblemaFID
    {
        private int ID_FIN_INDIRECTO = 0;
        private string FIN_INDIRECTO = "";

        private int ID_EFECTO_INDIRECTO = 0;

        /// Método constructor de la clase       
        public ArbolProblemaFID()
        {
        }

        #region Atributos de los fines indirectos
        public int IdFinIndirecto
        {
            get { return ID_FIN_INDIRECTO; }
            set { ID_FIN_INDIRECTO = value; }
        }
        public string FinIndirecto
        {
            get { return FIN_INDIRECTO; }
            set { FIN_INDIRECTO = value; }
        }
        public int IdEfectoIndirecto
        {
            get { return ID_EFECTO_INDIRECTO; }
            set { ID_EFECTO_INDIRECTO = value; }
        }
        #endregion
    }

    public class ArbolProblemaOED
    {
        private int ID_CAUSA_DIRECTA = 0;
        private string CAUSA_INDIRECTA = "";

        private int ID_OBJETIVO_DIRECTO = 0;
        private string OBJETIVO_DIRECTO = "";

        private List<ArbolProblemaOEID> LST_OEID = new List<ArbolProblemaOEID>();

        /// Método constructor de la clase       
        public ArbolProblemaOED()
        {
        }

        #region Atributos de los Objetivos especificos directos
        public int IdCausaDirecta
        {
            get { return ID_CAUSA_DIRECTA; }
            set { ID_CAUSA_DIRECTA = value; }
        }
        public string CausaDirecta
        {
            get { return CAUSA_INDIRECTA; }
            set { CAUSA_INDIRECTA = value; }
        }
        public int IdObjetivoDirecto
        {
            get { return ID_OBJETIVO_DIRECTO; }
            set { ID_OBJETIVO_DIRECTO = value; }
        }
        public string ObjetivoDirecto
        {
            get { return OBJETIVO_DIRECTO; }
            set { OBJETIVO_DIRECTO = value; }
        }
        public List<ArbolProblemaOEID> ObjetivosIndirectos
        {
            get { return LST_OEID; }
            set { LST_OEID = value; }
        }
        #endregion
    }

    public class ArbolProblemaOEID
    {
        private int ID_CAUSA_INDIRECTA = 0;

        private int ID_OBJETIVO_INDIRECTO = 0;
        private string OBJETIVO_INDIRECTO = "";

        /// Método constructor de la clase       
        public ArbolProblemaOEID()
        {
        }

        #region Atributos de los Objetivos especificos indirectos
        public int IdCausaIndirecta
        {
            get { return ID_CAUSA_INDIRECTA; }
            set { ID_CAUSA_INDIRECTA = value; }
        }
        public int IdObjetivoIndirecto
        {
            get { return ID_OBJETIVO_INDIRECTO; }
            set { ID_OBJETIVO_INDIRECTO = value; }
        }
        public string ObjetivoIndirecto
        {
            get { return OBJETIVO_INDIRECTO; }
            set { OBJETIVO_INDIRECTO = value; }
        }
        #endregion
    }

    public class InstrumentosBeneficios
    {
        private string NOMBRE_BENEFICIO = "";
        private string DESCRIPCION_BENEFICIO = "";

        /// Método constructor de la clase       
        public InstrumentosBeneficios()
        {
        }

        #region Atributos de los Beneficios
        public string NombreBeneficio
        {
            get { return NOMBRE_BENEFICIO; }
            set { NOMBRE_BENEFICIO = value; }
        }
        public string DescripcionBeneficio
        {
            get { return DESCRIPCION_BENEFICIO; }
            set { DESCRIPCION_BENEFICIO = value; }
        }
        #endregion
    }

    public class InstrumentosCadenaValor
    {
        private int ID_ATRIBUTO = 0;
        private string ATRIBUTO = "";
        private int ID_OBJETIVO_ESPECIFICO = 0;
        private string OBJETIVO_ESPECIFICO = "";
        private List<InstrumentosCVProductos> PRODUCTOS = new List<InstrumentosCVProductos>();
        private System.Web.UI.WebControls.ListItemCollection DDL_PRODS = new System.Web.UI.WebControls.ListItemCollection();

        private bool CONSULTA = false;

        /// Método constructor de la clase       
        public InstrumentosCadenaValor()
        {
        }

        #region Atributos de la Cadena de Valor
        public string Atributo
        {
            get { return ATRIBUTO; }
            set { ATRIBUTO = value; }
        }
        public int IdAtributo
        {
            get { return ID_ATRIBUTO; }
            set { ID_ATRIBUTO = value; }
        }
        public int IdObjetivoEspecifico
        {
            get { return ID_OBJETIVO_ESPECIFICO; }
            set { ID_OBJETIVO_ESPECIFICO = value; }
        }
        public string ObjetivoEspecifico
        {
            get { return OBJETIVO_ESPECIFICO; }
            set { OBJETIVO_ESPECIFICO = value; }
        }
        public List<InstrumentosCVProductos> Productos
        {
            get { return PRODUCTOS; }
            set { PRODUCTOS = value; }
        }
        public System.Web.UI.WebControls.ListItemCollection DdlProds
        {
            get { return DDL_PRODS; }
            set { DDL_PRODS = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosCVProductos
    {
        private int ID_ATRIBUTO = 0;
        private int ID_PRODUCTO = 0;
        private int ID_PRODUCTO_CV = 0;
        private string PRODUCTO = "";
        private string MEDIDA = "";
        private string UNIDAD = "";
        private string MEDIDO = "";
        private string INDICADOR = "";
        private string DESCRIPCION = "";
        private string JUSTIFICACION = "";
        private int META_TOTAL = 0;
        private List<InstrumentosActividadesProductos> ACTIVIDADES = new List<InstrumentosActividadesProductos>();

        private bool CONSULTA = false;

        /// Método constructor de la clase       
        public InstrumentosCVProductos()
        {
        }

        #region Atributos de los Productos
        public string Producto
        {
            get { return PRODUCTO; }
            set { PRODUCTO = value; }
        }
        public int IdAtributo
        {
            get { return ID_ATRIBUTO; }
            set { ID_ATRIBUTO = value; }
        }
        public int IdProducto
        {
            get { return ID_PRODUCTO; }
            set { ID_PRODUCTO = value; }
        }
        public int IdProductoCV
        {
            get { return ID_PRODUCTO_CV; }
            set { ID_PRODUCTO_CV = value; }
        }
        public string Medida
        {
            get { return MEDIDA; }
            set { MEDIDA = value; }
        }
        public string UnidadMedida
        {
            get { return UNIDAD; }
            set { UNIDAD = value; }
        }
        public string Medido
        {
            get { return MEDIDO; }
            set { MEDIDO = value; }
        }
        public string Indicador
        {
            get { return INDICADOR; }
            set { INDICADOR = value; }
        }
        public string Descripcion
        {
            get { return DESCRIPCION; }
            set { DESCRIPCION = value; }
        }
        public string Justificacion
        {
            get { return JUSTIFICACION; }
            set { JUSTIFICACION = value; }
        }
        public int MetaTotal
        {
            get { return META_TOTAL; }
            set { META_TOTAL = value; }
        }
        public List<InstrumentosActividadesProductos> Actividades
        {
            get { return ACTIVIDADES; }
            set { ACTIVIDADES = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosActividadesProductos
    {
        private int ID_ACTIVIDAD = 0;
        private int ID_CLASIFICACION = 0;
        private string CLASIFICACION = "";
        private string ACTIVIDADES = "";
        private string DESCRIPCION = "";
        private int ID_ETAPA = 0;
        private string ETAPA = "";
        private bool RUTA_CRITICA = false;
        private int COSTO_ANNO_1 = 0;
        private int COSTO_ANNO_2 = 0;
        private int COSTO_ANNO_3 = 0;
        private int COSTO_TOTAL = 0;

        private bool CONSULTA = false;

        /// Método constructor de la clase       
        public InstrumentosActividadesProductos()
        {
        }

        #region Atributos de las Actividades por producto
        public int IdActividad
        {
            get { return ID_ACTIVIDAD; }
            set { ID_ACTIVIDAD = value; }
        }
        public int IdClasificacion
        {
            get { return ID_CLASIFICACION; }
            set { ID_CLASIFICACION = value; }
        }
        public string Clasificacion
        {
            get { return CLASIFICACION; }
            set { CLASIFICACION = value; }
        }
        public string Actividades
        {
            get { return ACTIVIDADES; }
            set { ACTIVIDADES = value; }
        }
        public string Descripcion
        {
            get { return DESCRIPCION; }
            set { DESCRIPCION = value; }
        }
        public int IdEtapa
        {
            get { return ID_ETAPA; }
            set { ID_ETAPA = value; }
        }
        public string Etapa
        {
            get { return ETAPA; }
            set { ETAPA = value; }
        }
        public bool RutaCritica
        {
            get { return RUTA_CRITICA; }
            set { RUTA_CRITICA = value; }
        }
        public int CostoAnno1
        {
            get { return COSTO_ANNO_1; }
            set { COSTO_ANNO_1 = value; }
        }
        public int CostoAnno2
        {
            get { return COSTO_ANNO_2; }
            set { COSTO_ANNO_2 = value; }
        }
        public int CostoAnno3
        {
            get { return COSTO_ANNO_3; }
            set { COSTO_ANNO_3 = value; }
        }
        public int CostoTotal
        {
            get { return COSTO_TOTAL; }
            set { COSTO_TOTAL = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosInvolucrados
    {
        private int ID_TIPO_ACTOR = 0;
        private string TIPO_ACTOR = "";
        private string NOMBRE_ACTOR = "";
        private int ID_ROL_ACTOR = 0;
        private string ROL_ACTOR = "";
        private string INTERES_ACTOR = "";
        private int ID_INFLUENCIA_ACTOR = 0;
        private string INFLUENCIA_ACTOR = "";
        private string ESTRATEGIA_ACTOR = "";
        private string CONTRIBUCION_ACTOR = "";

        private bool CONSULTA = false;

        /// Método constructor de la clase       
        public InstrumentosInvolucrados()
        {
        }

        #region Atributos de los Involucrados
        public int IdTipoActor
        {
            get { return ID_TIPO_ACTOR; }
            set { ID_TIPO_ACTOR = value; }
        }
        public string TipoActor
        {
            get { return TIPO_ACTOR; }
            set { TIPO_ACTOR = value; }
        }
        public string NombreActor
        {
            get { return NOMBRE_ACTOR; }
            set { NOMBRE_ACTOR = value; }
        }
        public int IdRolActor
        {
            get { return ID_ROL_ACTOR; }
            set { ID_ROL_ACTOR = value; }
        }
        public string RolActor
        {
            get { return ROL_ACTOR; }
            set { ROL_ACTOR = value; }
        }
        public string InteresActor
        {
            get { return INTERES_ACTOR; }
            set { INTERES_ACTOR = value; }
        }
        public int IdInfluenciaActor
        {
            get { return ID_INFLUENCIA_ACTOR; }
            set { ID_INFLUENCIA_ACTOR = value; }
        }
        public string InfluenciaActor
        {
            get { return INFLUENCIA_ACTOR; }
            set { INFLUENCIA_ACTOR = value; }
        }
        public string EstrategiaActor
        {
            get { return ESTRATEGIA_ACTOR; }
            set { ESTRATEGIA_ACTOR = value; }
        }
        public string ContribucionActor
        {
            get { return CONTRIBUCION_ACTOR; }
            set { CONTRIBUCION_ACTOR = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosRiesgos
    {
        private int ID = 0;
        private string NOMBRE = "";
        private string DESCRIPCION_RIESGO = "";
        private int ID_TIPO_RIESGO = 0;
        private string TIPO_RIESGO = "";
        private int ID_PROB_RIESGO = 0;
        private string PROB_RIESGO = "";
        private int ID_IMPC_RIESGO = 0;
        private string IMPC_RIESGO = "";
        private string EFECTO_RIESGO = "";
        private string MITIGA_RIESGO = "";

        private bool CONSULTA = false;

        /// Método constructor de la clase  
        public InstrumentosRiesgos()
        {
        }

        #region Atributos de los Riesgos
        public int Id
        {
            get { return ID; }
            set { ID = value; }
        }
        public string Nombre
        {
            get { return NOMBRE; }
            set { NOMBRE = value; }
        }
        public string DescripcionRiesgo
        {
            get { return DESCRIPCION_RIESGO; }
            set { DESCRIPCION_RIESGO = value; }
        }
        public int IdTipoRiesgo
        {
            get { return ID_TIPO_RIESGO; }
            set { ID_TIPO_RIESGO = value; }
        }
        public string TipoRiesgo
        {
            get { return TIPO_RIESGO; }
            set { TIPO_RIESGO = value; }
        }
        public int IdProbabilidadRiesgo
        {
            get { return ID_PROB_RIESGO; }
            set { ID_PROB_RIESGO = value; }
        }
        public string ProbabilidadRiesgo
        {
            get { return PROB_RIESGO; }
            set { PROB_RIESGO = value; }
        }
        public int IdImpactoRiesgo
        {
            get { return ID_IMPC_RIESGO; }
            set { ID_IMPC_RIESGO = value; }
        }
        public string ImpactoRiesgo
        {
            get { return IMPC_RIESGO; }
            set { IMPC_RIESGO = value; }
        }
        public string EfectoRiesgo
        {
            get { return EFECTO_RIESGO; }
            set { EFECTO_RIESGO = value; }
        }
        public string MitigacionRiesgo
        {
            get { return MITIGA_RIESGO; }
            set { MITIGA_RIESGO = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosRiesgoProductos
    {
        private int ID = 0;
        private string NOMBRE = "";
        private string NUM = "";

        private List<InstrumentosRiesgos> LISTA_RIESGOS = new List<InstrumentosRiesgos>();

        private bool CONSULTA = false;

        /// Método constructor de la clase  
        public InstrumentosRiesgoProductos()
        {
        }

        #region Atributos de los Riesgos
        public int Id
        {
            get { return ID; }
            set { ID = value; }
        }
        public string Nombre
        {
            get { return NOMBRE; }
            set { NOMBRE = value; }
        }
        public string Num
        {
            get { return NUM; }
            set { NUM = value; }
        }
        public List<InstrumentosRiesgos> Riesgos
        {
            get { return LISTA_RIESGOS; }
            set { LISTA_RIESGOS = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosRiesgoProductosActividades
    {
        private int ID = 0;
        private string NOMBRE = "";
        private string NUM = "";

        private List<InstrumentosRiesgoActividades> LISTA_ACTIVIDADES = new List<InstrumentosRiesgoActividades>();

        private bool CONSULTA = false;

        /// Método constructor de la clase  
        public InstrumentosRiesgoProductosActividades()
        {
        }

        #region Atributos de los Riesgos
        public int Id
        {
            get { return ID; }
            set { ID = value; }
        }
        public string Nombre
        {
            get { return NOMBRE; }
            set { NOMBRE = value; }
        }
        public string Num
        {
            get { return NUM; }
            set { NUM = value; }
        }
        public List<InstrumentosRiesgoActividades> Actividades
        {
            get { return LISTA_ACTIVIDADES; }
            set { LISTA_ACTIVIDADES = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosRiesgoActividades
    {
        private int ID = 0;
        private int ID_PRODUCTO = 0;
        private string NOMBRE = "";
        private string NUM = "";

        private List<InstrumentosRiesgos> LISTA_RIESGOS = new List<InstrumentosRiesgos>();

        private bool CONSULTA = false;

        /// Método constructor de la clase  
        public InstrumentosRiesgoActividades()
        {
        }

        #region Atributos de los Riesgos
        public int Id
        {
            get { return ID; }
            set { ID = value; }
        }
        public int IdProducto
        {
            get { return ID_PRODUCTO; }
            set { ID_PRODUCTO = value; }
        }
        public string Nombre
        {
            get { return NOMBRE; }
            set { NOMBRE = value; }
        }
        public string Num
        {
            get { return NUM; }
            set { NUM = value; }
        }
        public List<InstrumentosRiesgos> Riesgos
        {
            get { return LISTA_RIESGOS; }
            set { LISTA_RIESGOS = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosProductoSeguimiento
    {
        private int ID_PRODUCTO = 0;
        private int ID_PRODUCTO_CV = 0;
        private string PRODUCTO = "";
        private string MEDIDA = "";
        private string UNIDAD = "";
        private string MEDIDO = "";
        private string INDICADOR = "";
        private string DESCRIPCION = "";
        private int META_TOTAL = 0;
        private int COSTO_ANNO_1 = 0;
        private int COSTO_ANNO_2 = 0;
        private int COSTO_ANNO_3 = 0;
        private int ANNO1 = 0;
        private int ANNO2 = 0;
        private int ANNO3 = 0;
        private int ID_TIPO_FUENTE = 0;
        private string TIPO_FUENTE = "";
        private string FUENTE = "";

        private bool CONSULTA = false;

        /// Método constructor de la clase  
        public InstrumentosProductoSeguimiento()
        {
        }

        #region Atributos de los Productos para Seguimiento
        public string Producto
        {
            get { return PRODUCTO; }
            set { PRODUCTO = value; }
        }
        public int IdProducto
        {
            get { return ID_PRODUCTO; }
            set { ID_PRODUCTO = value; }
        }
        public int IdProductoCV
        {
            get { return ID_PRODUCTO_CV; }
            set { ID_PRODUCTO_CV = value; }
        }
        public string Medida
        {
            get { return MEDIDA; }
            set { MEDIDA = value; }
        }
        public string UnidadMedida
        {
            get { return UNIDAD; }
            set { UNIDAD = value; }
        }
        public string Medido
        {
            get { return MEDIDO; }
            set { MEDIDO = value; }
        }
        public string Indicador
        {
            get { return INDICADOR; }
            set { INDICADOR = value; }
        }
        public string Descripcion
        {
            get { return DESCRIPCION; }
            set { DESCRIPCION = value; }
        }
        public int MetaTotal
        {
            get { return META_TOTAL; }
            set { META_TOTAL = value; }
        }
        public int CostoAnno1
        {
            get { return COSTO_ANNO_1; }
            set { COSTO_ANNO_1 = value; }
        }
        public int CostoAnno2
        {
            get { return COSTO_ANNO_2; }
            set { COSTO_ANNO_2 = value; }
        }
        public int CostoAnno3
        {
            get { return COSTO_ANNO_3; }
            set { COSTO_ANNO_3 = value; }
        }
        public int Anno1
        {
            get { return ANNO1; }
            set { ANNO1 = value; }
        }
        public int Anno2
        {
            get { return ANNO2; }
            set { ANNO2 = value; }
        }
        public int Anno3
        {
            get { return ANNO3; }
            set { ANNO3 = value; }
        }
        public int IdTipoFuente
        {
            get { return ID_TIPO_FUENTE; }
            set { ID_TIPO_FUENTE = value; }
        }
        public string TipoFuente
        {
            get { return TIPO_FUENTE; }
            set { TIPO_FUENTE = value; }
        }
        public string Fuente
        {
            get { return FUENTE; }
            set { FUENTE = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosActividadesSeguimiento
    {
        private int ID_ACTIVIDAD = 0;
        private int ID_ACTIVIDAD_CV = 0;
        private string ACTIVIDAD = "";
        private string MEDIDA = "";
        private string UNIDAD = "";
        private string MEDIDO = "";
        private int ID_INDICADOR = 0;
        private string INDICADOR = "";
        private string DESCRIPCION = "";
        private int COSTO_ANNO_1 = 0;
        private int COSTO_ANNO_2 = 0;
        private int COSTO_ANNO_3 = 0;
        private int COSTO_TOTAL = 0;
        private int ANNO1 = 0;
        private int ANNO2 = 0;
        private int ANNO3 = 0;
        private int ID_TIPO_FUENTE = 0;
        private string TIPO_FUENTE = "";
        private string FUENTE = "";

        private bool CONSULTA = false;

        /// Método constructor de la clase  
        public InstrumentosActividadesSeguimiento()
        {
        }

        #region Atributos de las Actividades para Seguimiento
        public string Actividad
        {
            get { return ACTIVIDAD; }
            set { ACTIVIDAD = value; }
        }
        public int IdActividad
        {
            get { return ID_ACTIVIDAD; }
            set { ID_ACTIVIDAD = value; }
        }
        public int IdActividadCV
        {
            get { return ID_ACTIVIDAD_CV; }
            set { ID_ACTIVIDAD_CV = value; }
        }
        public string Medida
        {
            get { return MEDIDA; }
            set { MEDIDA = value; }
        }
        public string UnidadMedida
        {
            get { return UNIDAD; }
            set { UNIDAD = value; }
        }
        public string Medido
        {
            get { return MEDIDO; }
            set { MEDIDO = value; }
        }
        public int IdIndicador
        {
            get { return ID_INDICADOR; }
            set { ID_INDICADOR = value; }
        }
        public string Indicador
        {
            get { return INDICADOR; }
            set { INDICADOR = value; }
        }
        public string Descripcion
        {
            get { return DESCRIPCION; }
            set { DESCRIPCION = value; }
        }
        public int CostoAnno1
        {
            get { return COSTO_ANNO_1; }
            set { COSTO_ANNO_1 = value; }
        }
        public int CostoAnno2
        {
            get { return COSTO_ANNO_2; }
            set { COSTO_ANNO_2 = value; }
        }
        public int CostoAnno3
        {
            get { return COSTO_ANNO_3; }
            set { COSTO_ANNO_3 = value; }
        }
        public int CostoTotal
        {
            get { return COSTO_TOTAL; }
            set { COSTO_TOTAL = value; }
        }
        public int Anno1
        {
            get { return ANNO1; }
            set { ANNO1 = value; }
        }
        public int Anno2
        {
            get { return ANNO2; }
            set { ANNO2 = value; }
        }
        public int Anno3
        {
            get { return ANNO3; }
            set { ANNO3 = value; }
        }
        public int IdTipoFuente
        {
            get { return ID_TIPO_FUENTE; }
            set { ID_TIPO_FUENTE = value; }
        }
        public string TipoFuente
        {
            get { return TIPO_FUENTE; }
            set { TIPO_FUENTE = value; }
        }
        public string Fuente
        {
            get { return FUENTE; }
            set { FUENTE = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }    

    public class InstrumentosCronogramaAtributos
    {
        private int ID_ATRIBUTO = 0;
        private string ATRIBUTO = "";
        private int ID_OBJETIVO_ESPECIFICO = 0;
        private string OBJETIVO_ESPECIFICO = "";
        private List<InstrumentosCronogramaProductos> PRODUCTOS = new List<InstrumentosCronogramaProductos>();

        private bool CONSULTA = false;

        /// Método constructor de la clase       
        public InstrumentosCronogramaAtributos()
        {
        }

        #region Atributos de los atributos del cronograma
        public string Atributo
        {
            get { return ATRIBUTO; }
            set { ATRIBUTO = value; }
        }
        public int IdAtributo
        {
            get { return ID_ATRIBUTO; }
            set { ID_ATRIBUTO = value; }
        }
        public int IdObjetivoEspecifico
        {
            get { return ID_OBJETIVO_ESPECIFICO; }
            set { ID_OBJETIVO_ESPECIFICO = value; }
        }
        public string ObjetivoEspecifico
        {
            get { return OBJETIVO_ESPECIFICO; }
            set { OBJETIVO_ESPECIFICO = value; }
        }
        public List<InstrumentosCronogramaProductos> Productos
        {
            get { return PRODUCTOS; }
            set { PRODUCTOS = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosCronogramaProductos
    {
        private int ID_ATRIBUTO = 0;
        private int ID_PRODUCTO = 0;
        private int ID_PRODUCTO_CV = 0;
        private string PRODUCTO = "";
        private string MEDIDA = "";
        private string UNIDAD = "";
        private string MEDIDO = "";
        private string INDICADOR = "";
        private string DESCRIPCION = "";
        private int META_TOTAL = 0;
        private List<InstrumentosCronogramaActividadesProductos> ACTIVIDADES = new List<InstrumentosCronogramaActividadesProductos>();

        private bool CONSULTA = false;

        /// Método constructor de la clase       
        public InstrumentosCronogramaProductos()
        {
        }

        #region Atributos de los Productos del Cronograma
        public string Producto
        {
            get { return PRODUCTO; }
            set { PRODUCTO = value; }
        }
        public int IdAtributo
        {
            get { return ID_ATRIBUTO; }
            set { ID_ATRIBUTO = value; }
        }
        public int IdProducto
        {
            get { return ID_PRODUCTO; }
            set { ID_PRODUCTO = value; }
        }
        public int IdProductoCV
        {
            get { return ID_PRODUCTO_CV; }
            set { ID_PRODUCTO_CV = value; }
        }
        public string Medida
        {
            get { return MEDIDA; }
            set { MEDIDA = value; }
        }
        public string UnidadMedida
        {
            get { return UNIDAD; }
            set { UNIDAD = value; }
        }
        public string Medido
        {
            get { return MEDIDO; }
            set { MEDIDO = value; }
        }
        public string Indicador
        {
            get { return INDICADOR; }
            set { INDICADOR = value; }
        }
        public string Descripcion
        {
            get { return DESCRIPCION; }
            set { DESCRIPCION = value; }
        }
        public int MetaTotal
        {
            get { return META_TOTAL; }
            set { META_TOTAL = value; }
        }
        public List<InstrumentosCronogramaActividadesProductos> Actividades
        {
            get { return ACTIVIDADES; }
            set { ACTIVIDADES = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosCronogramaActividadesProductos
    {
        private int ID_ACTIVIDAD = 0;
        private int ID_CLASIFICACION = 0;
        private string CLASIFICACION = "";
        private string ACTIVIDADES = "";
        private string DESCRIPCION = "";
        private int ID_ETAPA = 0;
        private string ETAPA = "";
        private bool RUTA_CRITICA = false;
        private int COSTO_ANNO_1 = 0;
        private int COSTO_ANNO_2 = 0;
        private int COSTO_ANNO_3 = 0;
        private int COSTO_TOTAL = 0;

        private List<InstrumentosCronogramaProductosActividadesTareas> TAREAS = new List<InstrumentosCronogramaProductosActividadesTareas>();

        private bool CONSULTA = false;

        /// Método constructor de la clase       
        public InstrumentosCronogramaActividadesProductos()
        {
        }

        #region Atributos de las Actividades por producto del cronograma
        public int IdActividad
        {
            get { return ID_ACTIVIDAD; }
            set { ID_ACTIVIDAD = value; }
        }
        public int IdClasificacion
        {
            get { return ID_CLASIFICACION; }
            set { ID_CLASIFICACION = value; }
        }
        public string Clasificacion
        {
            get { return CLASIFICACION; }
            set { CLASIFICACION = value; }
        }
        public string Actividades
        {
            get { return ACTIVIDADES; }
            set { ACTIVIDADES = value; }
        }
        public string Descripcion
        {
            get { return DESCRIPCION; }
            set { DESCRIPCION = value; }
        }
        public int IdEtapa
        {
            get { return ID_ETAPA; }
            set { ID_ETAPA = value; }
        }
        public string Etapa
        {
            get { return ETAPA; }
            set { ETAPA = value; }
        }
        public bool RutaCritica
        {
            get { return RUTA_CRITICA; }
            set { RUTA_CRITICA = value; }
        }
        public int CostoAnno1
        {
            get { return COSTO_ANNO_1; }
            set { COSTO_ANNO_1 = value; }
        }
        public int CostoAnno2
        {
            get { return COSTO_ANNO_2; }
            set { COSTO_ANNO_2 = value; }
        }
        public int CostoAnno3
        {
            get { return COSTO_ANNO_3; }
            set { COSTO_ANNO_3 = value; }
        }
        public int CostoTotal
        {
            get { return COSTO_TOTAL; }
            set { COSTO_TOTAL = value; }
        }
        public List<InstrumentosCronogramaProductosActividadesTareas> Tareas
        {
            get { return TAREAS; }
            set { TAREAS = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosCronogramaProductosActividadesTareas
    {
        private int ID_ATRIBUTO_CV = 0;
        private int ID_PRODUCTO_CV = 0;
        private int ID_ACTIVIDAD_CV = 0;
        private string TAREA = "";
        private string RESPONSABLE = "";
        private bool[] MESES_ANNO1 = new bool[12];
        private bool[] MESES_ANNO2 = new bool[12];
        private bool[] MESES_ANNO3 = new bool[12];
        private DateTime? fechaIni1 = null;
        private DateTime? fechaFin1 = null;
        private DateTime? fechaIni2 = null;
        private DateTime? fechaFin2 = null;
        private DateTime? fechaIni3 = null;
        private DateTime? fechaFin3 = null;

        private string strfechaIni1 = null;
        private string strfechaFin1 = null;
        private string strfechaIni2 = null;
        private string strfechaFin2 = null;
        private string strfechaIni3 = null;
        private string strfechaFin3 = null;

        private bool CONSULTA = false;

        /// Método constructor de la clase  
        public InstrumentosCronogramaProductosActividadesTareas()
        {
        }

        #region Atributos de las tareas del cronograma
        public int IdAtributoCV
        {
            get { return ID_ATRIBUTO_CV; }
            set { ID_ATRIBUTO_CV = value; }
        }
        public int IdProductoCV
        {
            get { return ID_PRODUCTO_CV; }
            set { ID_PRODUCTO_CV = value; }
        }
        public int IdActividadCV
        {
            get { return ID_ACTIVIDAD_CV; }
            set { ID_ACTIVIDAD_CV = value; }
        }
        public string Tarea
        {
            get { return TAREA; }
            set { TAREA = value; }
        }
        public string Responsable
        {
            get { return RESPONSABLE; }
            set { RESPONSABLE = value; }
        }
        public bool[] MesesAnno1
        {
            get { return MESES_ANNO1; }
            set { MESES_ANNO1 = value; }
        }
        public bool[] MesesAnno2
        {
            get { return MESES_ANNO2; }
            set { MESES_ANNO2 = value; }
        }
        public bool[] MesesAnno3
        {
            get { return MESES_ANNO3; }
            set { MESES_ANNO3 = value; }
        }
        public DateTime? FechaIni1
        {
            get { return fechaIni1; }
            set { fechaIni1 = value; }
        }

        public DateTime? FechaFin1
        {
            get { return fechaFin1; }
            set { fechaFin1 = value; }
        }

        public DateTime? FechaIni2
        {
            get { return fechaIni2; }
            set { fechaIni2 = value; }
        }

        public DateTime? FechaFin2
        {
            get { return fechaFin2; }
            set { fechaFin2 = value; }
        }

        public DateTime? FechaIni3
        {
            get { return fechaIni3; }
            set { fechaIni3 = value; }
        }

        public DateTime? FechaFin3
        {
            get { return fechaFin3; }
            set { fechaFin3 = value; }
        }

        public string strFechaIni1
        {
            get { return strfechaIni1; }
            set { strfechaIni1 = value; }
        }

        public string strFechaFin1
        {
            get { return strfechaFin1; }
            set { strfechaFin1 = value; }
        }

        public string strFechaIni2
        {
            get { return strfechaIni2; }
            set { strfechaIni2 = value; }
        }

        public string strFechaFin2
        {
            get { return strfechaFin2; }
            set { strfechaFin2 = value; }
        }

        public string strFechaIni3
        {
            get { return strfechaIni3; }
            set { strfechaIni3 = value; }
        }

        public string strFechaFin3
        {
            get { return strfechaFin3; }
            set { strfechaFin3 = value; }
        }

        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosResumenAtributos
    {
        private int ID_ATRIBUTO = 0;
        private string ATRIBUTO = "";
        private int ID_OBJETIVO_ESPECIFICO = 0;
        private string OBJETIVO_ESPECIFICO = "";
        private List<InstrumentosResumenProductos> PRODUCTOS = new List<InstrumentosResumenProductos>();

        private bool CONSULTA = false;

        /// Método constructor de la clase       
        public InstrumentosResumenAtributos()
        {
        }

        #region Atributos de los atributos de la matriz de resumen
        public string Atributo
        {
            get { return ATRIBUTO; }
            set { ATRIBUTO = value; }
        }
        public int IdAtributo
        {
            get { return ID_ATRIBUTO; }
            set { ID_ATRIBUTO = value; }
        }
        public int IdObjetivoEspecifico
        {
            get { return ID_OBJETIVO_ESPECIFICO; }
            set { ID_OBJETIVO_ESPECIFICO = value; }
        }
        public string ObjetivoEspecifico
        {
            get { return OBJETIVO_ESPECIFICO; }
            set { OBJETIVO_ESPECIFICO = value; }
        }
        public List<InstrumentosResumenProductos> Productos
        {
            get { return PRODUCTOS; }
            set { PRODUCTOS = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosResumenProductos
    {
        private int ID_ATRIBUTO = 0;
        private int ID_PRODUCTO = 0;
        private int ID_PRODUCTO_CV = 0;
        private string PRODUCTO = "";
        private string MEDIDA = "";
        private string UNIDAD = "";
        private string MEDIDO = "";
        private string INDICADOR = "";
        private string DESCRIPCION = "";
        private int META_TOTAL = 0;
        private string TIPO_FUENTE = "";
        private string FUENTE = "";
        private string SUPUESTOS = "";
        private string NUM = "";
        private List<InstrumentosResumenActividadesProductos> ACTIVIDADES = new List<InstrumentosResumenActividadesProductos>();

        private bool CONSULTA = false;

        /// Método constructor de la clase       
        public InstrumentosResumenProductos()
        {
        }

        #region Atributos de los Productos de la matriz de resumen
        public string Producto
        {
            get { return PRODUCTO; }
            set { PRODUCTO = value; }
        }
        public int IdAtributo
        {
            get { return ID_ATRIBUTO; }
            set { ID_ATRIBUTO = value; }
        }
        public int IdProducto
        {
            get { return ID_PRODUCTO; }
            set { ID_PRODUCTO = value; }
        }
        public int IdProductoCV
        {
            get { return ID_PRODUCTO_CV; }
            set { ID_PRODUCTO_CV = value; }
        }
        public string Medida
        {
            get { return MEDIDA; }
            set { MEDIDA = value; }
        }
        public string UnidadMedida
        {
            get { return UNIDAD; }
            set { UNIDAD = value; }
        }
        public string Medido
        {
            get { return MEDIDO; }
            set { MEDIDO = value; }
        }
        public string Indicador
        {
            get { return INDICADOR; }
            set { INDICADOR = value; }
        }
        public string Descripcion
        {
            get { return DESCRIPCION; }
            set { DESCRIPCION = value; }
        }
        public string TipoFuente
        {
            get { return TIPO_FUENTE; }
            set { TIPO_FUENTE = value; }
        }
        public string Fuente
        {
            get { return FUENTE; }
            set { FUENTE = value; }
        }
        public string Supuestos
        {
            get { return SUPUESTOS; }
            set { SUPUESTOS = value; }
        }
        public int MetaTotal
        {
            get { return META_TOTAL; }
            set { META_TOTAL = value; }
        }
        public string Num
        {
            get { return NUM; }
            set { NUM = value; }
        }
        public List<InstrumentosResumenActividadesProductos> Actividades
        {
            get { return ACTIVIDADES; }
            set { ACTIVIDADES = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        #endregion
    }

    public class InstrumentosResumenActividadesProductos
    {
        private int ID_PRODUCTO = 0;
        private int ID_ACTIVIDAD = 0;
        private int ID_CLASIFICACION = 0;
        private string CLASIFICACION = "";
        private string ACTIVIDADES = "";
        private string DESCRIPCION = "";
        private string ETAPA = "";
        private bool RUTA_CRITICA = false;
        private int COSTO_TOTAL = 0;
        private string SUPUESTOS = "";
        private string INDICADOR = "";
        private string TIPO_FUENTE = "";
        private string MEDIDO = "";
        private string FUENTE = "";
        private string NUM = "";

        private bool CONSULTA = false;

        /// Método constructor de la clase       
        public InstrumentosResumenActividadesProductos()
        {
        }

        #region Atributos de las Actividades por producto de la matriz de resumen
        public int IdActividad
        {
            get { return ID_ACTIVIDAD; }
            set { ID_ACTIVIDAD = value; }
        }
        public int IdProducto
        {
            get { return ID_PRODUCTO; }
            set { ID_PRODUCTO = value; }
        }
        public int IdClasificacion
        {
            get { return ID_CLASIFICACION; }
            set { ID_CLASIFICACION = value; }
        }
        public string Clasificacion
        {
            get { return CLASIFICACION; }
            set { CLASIFICACION = value; }
        }
        public string Actividades
        {
            get { return ACTIVIDADES; }
            set { ACTIVIDADES = value; }
        }
        public string Descripcion
        {
            get { return DESCRIPCION; }
            set { DESCRIPCION = value; }
        }
        public string Etapa
        {
            get { return ETAPA; }
            set { ETAPA = value; }
        }
        public bool RutaCritica
        {
            get { return RUTA_CRITICA; }
            set { RUTA_CRITICA = value; }
        }
        public string Medido
        {
            get { return MEDIDO; }
            set { MEDIDO = value; }
        }
        public int CostoTotal
        {
            get { return COSTO_TOTAL; }
            set { COSTO_TOTAL = value; }
        }
        public string Indicador
        {
            get { return INDICADOR; }
            set { INDICADOR = value; }
        }
        public string TipoFuente
        {
            get { return TIPO_FUENTE; }
            set { TIPO_FUENTE = value; }
        }
        public string Fuente
        {
            get { return FUENTE; }
            set { FUENTE = value; }
        }
        public string Supuestos
        {
            get { return SUPUESTOS; }
            set { SUPUESTOS = value; }
        }
        public bool Consulta
        {
            get { return CONSULTA; }
            set { CONSULTA = value; }
        }
        public string Num
        {
            get { return NUM; }
            set { NUM = value; }
        }
        #endregion
    }

    public class DatosPDFPIRC
    {
        public string IDENT_PROBLEMA { get; set; }
        public string IDENT_OBJETIVOS { get; set; }
        public string POBLACION_AFECT_OBJ { get; set; }
        public string LOCALIZACION { get; set; }
        public string ASPECTO_ESTRATEG { get; set; }
        public string ASPECTO_LEGAL { get; set; }
        public string ASPECTO_TECNICO { get; set; }
        public string ASPECTO_FINANCIERO { get; set; }
        public string ASPECTO_SOSTENIBILIDAD { get; set; }
        public string ASPECTO_POLITICO { get; set; }
        public string IMPLICAC_INSTITUCIONALES { get; set; }
        public string BENEFICIOS_PIRC { get; set; }
        public string PROF_PIRC_RC { get; set; }
        public string PROF_PIRC_PSICO { get; set; }
        public string PROF_PIRC_SATISF { get; set; }
        public string PROF_PIRC_REHAB { get; set; }
        public string PROF_PIRC_GARAN { get; set; }
        public string PROF_PIRC_RESTIT { get; set; }
        public string PROF_REV_TECNICA { get; set; }
        public string ASPECTO_SOCIAL { get; set; }
    }

    public class DatosPDFPoblacion
    {
        public string POB_AFEC_QUIEN { get; set; }
        public string POB_OBJ_QUIEN { get; set; }
        public string POB_AFEC_CARAC { get; set; }
        public string POB_OBJ_CARAC { get; set; }
        public string POB_AFEC_CANT { get; set; }
        public string POB_OBJ_CANT { get; set; }
        public string POB_AFEC_UBICA { get; set; }
        public string POB_OBJ_UBICA { get; set; }
    }

    public class DatosListaMedidas
    {
        public string Medida { get; set; }
    }

    public class DatosReporteProducto
    {
        public string NombreSujeto { get; set; }
        public string Nit { get; set; }
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public string Indicador { get; set; }
        public string Medida { get; set; }
        public string Justificacion { get; set; }
        public string Atributo { get; set; }
        public string Objetivo { get; set; }
    }

    public class DatosReporteCostoActividad
    {
        public string TipoActividad { get; set; }
        public string Costo1 { get; set; }
        public string Costo2 { get; set; }
        public string Costo3 { get; set; }
        public string CostoTotal { get; set; }
    }
}