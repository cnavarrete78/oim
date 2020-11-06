/*
 ***************************************************************************************************
  PROGRAMA				: FachadaPersistencia.cs
  AUTOR                 : Gustavo Adolfo Caicedo Viveros
  FECHA DE CREACION	    : Junio 16 de 2010
  USUARIO MODIFICA      : Emerson Pulido
  FECHA DE MODIFICACION : 02-08-2020
  VERSION               : 3.9
 ***************************************************************************************************
  CLASE			        : FachadaPersistencia
  RESPONSABILIDAD	    : Se encarga se encarga de gestionar los llamados para crear participantes,
                          entidades en el sistema, encripcion, log, reportes, etc
  COLABORACION		    : Alejandro Moreno
****************************************************************************************************
*/

using System;
using System.Data;
using com.GACV.lgb.modelo;
using com.GACV.lgb.modelo.usuario;
using com.GACV.lgb.persistencia.dao;

using com.GACV.lgb.modelo.pass_randomico;

using com.GACV.lgb.modelo.sujeto_colectiva;

using com.GACV.lgb.modelo.persona;

using com.GACV.lgb.modelo.actividad;
using com.GACV.lgb.modelo.actividad_detalle;
using com.GACV.lgb.modelo.actividad_responsable;
using com.GACV.lgb.modelo.actividad_cobertura;

using com.GACV.lgb.modelo.actividad_dia;
using com.GACV.lgb.modelo.adjuntar_archivos_act;

using com.GACV.lgb.modelo.crear_mensajes;

using com.GACV.lgb.modelo.Actividad_dia_bitacora;
using com.GACV.lgb.modelo.actividad_dia_costo;
using com.GACV.lgb.modelo.actividad_producto;

using com.GACV.lgb.modelo.ADES;
using com.GACV.lgb.DAO.ADES;

using com.GACV.lgb.modelo.ADEP;
using com.GACV.lgb.DAO.ADEP;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace com.GACV.lgb.persistencia.fachada
{
    // Clase encargada de gestionar el camino para realizar consultas sobre la base de procesos y sobre la base de datos de la lógica del negocio.    
    public class FachadaPersistencia
    {
        // Declaracion de las clases
        protected static FachadaPersistencia instancia;

        private DAOListasDesplegables L_D = new DAOListasDesplegables();

        private DAOComunitario comunitario = new DAOComunitario();
        
        private DAOColectiva colectiva = new DAOColectiva();
        
        private DAOActividad Actividades = new DAOActividad();
        private DAOActividad_detalle Actividad_detalle = new DAOActividad_detalle();
        private DAOActividad_responsable Actividad_Responsable = new DAOActividad_responsable();
        private DAOActividad_cobertura Actividad_Cobertura = new DAOActividad_cobertura();
        private DAOActividad_dia Actividad_Dia = new DAOActividad_dia();
        private DAOAdjuntar_archivos_act archivos_act = new DAOAdjuntar_archivos_act();
        
        protected DAOPermisos permisos = new DAOPermisos();
        protected DAOPersonas Personas = new DAOPersonas();
        protected DAOUsuarios usuarios = new DAOUsuarios();
        private DAOEncripta daoEnc = new DAOEncripta();
        private pass_randomico pass_rand = new pass_randomico();
        private DAOcrearmensajes mensaje = new DAOcrearmensajes();
        
        private DAOActividad_dia_encuesta_solucion DAOADES = new DAOActividad_dia_encuesta_solucion();
        
        private DAOActividad_dia_encuesta_pregunta DAOADEP = new DAOActividad_dia_encuesta_pregunta();

        //DAOMGA
        private DAOMGA daoMGA = new DAOMGA();

        
        // Método constructor de la clase       
        public FachadaPersistencia()
        {
        }

        // Metodo generador de la única instancia de la clase retorna instancia de la clase        
        public static FachadaPersistencia getInstancia()
        {
            if (instancia == null)
                instancia = new FachadaPersistencia();
            return instancia;
        }

        #region LISTAS DESPLEGABLES

        // cargar los items de la lista paises
        public DataSet L_D_Pais()
        {
            return L_D.L_D_Pais();
        }

        // cargar los items de la lista departamentos
        public DataSet L_D_Departamento()
        {
            return L_D.L_D_Departamento();
        }

        // cargar los items de la lista departamentos
        public DataSet L_D_Departamento_territorial(int id_territorial)
        {
            return L_D.L_D_Departamento_territorial(id_territorial);
        }

        // cargar los items de la lista departamentos
        public DataSet L_D_Municipio_Dep_territorial(int id_territorial, int id_departamento)
        {
            return L_D.L_D_Municipio_Dep_territorial(id_territorial, id_departamento);
        }

        // SE REALIZO EL CAMBIO DE SP A --> SP_MUNICIPIO
        // cargar los items de la lista municipios segun el departamento seleccionado
        //public DataSet L_D_Municipio(int id_departamento)
        public DataSet L_D_Municipio(int id_departamento, int id_territorial, int opcion)
        {
            //return L_D.L_D_Municipio(id_departamento);
            return L_D.L_D_Municipio(id_departamento, id_territorial, opcion);
        }

        public DataSet L_D_tipo_vinculacion(int opcion)
        {
            //return L_D.L_D_Municipio(id_departamento);
            return L_D.L_D_tipo_vinculacion(opcion);
        }


        // cargar los items de la lista de ciudades segun el pais
        public DataSet L_D_Ciudades(int id_pais)
        {
            return L_D.L_D_Ciudades(id_pais);
        }

        // cargar los items de la lista municipios segun el departamento seleccionado
        public DataSet L_D_Municipio_oferta(int id_departamento, int id_oferta)
        {
            return L_D.L_D_Municipio_oferta(id_departamento, id_oferta);
        }

        public DataSet L_D_Tipo_piri(int id_tipo_usuario)
        {
            return L_D.L_D_Tipo_piri(id_tipo_usuario);
        }

        // permite cargar la lista de categorias
        public DataSet L_D_Lista_categoria(int id_tipo_priri)
        {
            return L_D.L_D_Lista_categoria(id_tipo_priri);
        }

        public DataSet L_D_Tipo_sub_estados(int opcion)
        {
            return L_D.L_D_Tipo_sub_estados(opcion);
        }

        public DataSet L_D_Encuestador(int id_departamento, int id_municipio, int id_usuario, int id_tipo_usuario)
        {
            return L_D.L_D_Encuestador(id_departamento, id_municipio, id_usuario, id_tipo_usuario);
        }

        public DataSet LD_territorial_oferta(int id_departamento)
        {
            return L_D.LD_territorial_oferta(id_departamento);
        }

        // listado de los tipos de acciones
        public DataSet LD_tipo_accion()
        {
            return L_D.LD_tipo_accion();
        }

        // listado de los tipos de acciones
        public DataSet LD_Entidad_oferta()
        {
            return L_D.LD_Entidad_oferta();
        }

        // listado de los tipos de acciones
        public DataSet LD_L1_oferta(int id_tipo_oferta)
        {
            return L_D.LD_L1_oferta(id_tipo_oferta);
        }

        // listado de los tipos de acciones
        public DataSet LD_modalidad_oferta()
        {
            return L_D.LD_modalidad_oferta();
        }

        // listado de la preriodicidad de la oferta
        public DataSet LD_Periodicidad_oferta()
        {
            return L_D.LD_Periodicidad_oferta();
        }

        // listado del estado de la oferta
        public DataSet LD_Estado_oferta()
        {
            return L_D.LD_Estado_oferta();
        }

        // cargar los items de la lista departamentos
        public DataSet L_D_Tipo_identificacion()
        {
            return L_D.L_D_Tipo_identificacion();
        }

        public DataSet L_D_Estado()
        {
            return L_D.L_D_Estado();
        }

        public DataSet L_D_Tipo_usuario()
        {
            return L_D.L_D_Tipo_usuario();
        }

        public DataSet L_D_Tipo_novedad()
        {
            return L_D.L_D_Tipo_novedad();
        }

        public DataSet L_D_alcance(int rol)
        {
            return L_D.L_D_alcance(rol);
        }

        public DataSet LD_tipo_entidad()
        {
            return L_D.LD_tipo_entidad();
        }

        public DataSet LD_entidad(int id_alcance, int id_departamento, int id_municipio, int rol, int opcion)
        {
            return L_D.LD_entidad(id_alcance, id_departamento, id_municipio, rol, opcion);
        }

        
        public DataSet LD_usuarios(int id_departamento, int id_municipio, int rol, int opcion)
        {
            return L_D.LD_usuarios(id_departamento, id_municipio, rol, opcion);
        }

        public DataSet LD_genero()
        {
            return L_D.LD_genero();
        }

        public DataSet L_D_Tipo_cobertura()
        {
            return L_D.L_D_Tipo_cobertura();
        }

        public DataSet L_D_Supervisor(Usuario usuario, int opcion)
        {
            return L_D.L_D_Supervisor(usuario, opcion);
        }

        // categoria de las ofertas
        public DataSet L_D_Categoria()
        {
            return L_D.L_D_Categoria();
        }

        // modulos de las ofertas
        public DataSet L_D_Modulo(int id_categoria)
        {
            return L_D.L_D_Modulo(id_categoria);
        }

        //nivel requerido para acceder a la oferta
        public DataSet LD_periodicidad_pago()
        {
            return L_D.LD_periodicidad_pago();
        }

        //nivel requerido para acceder a la oferta
        public DataSet LD_programa_marco()
        {
            return L_D.LD_programa_marco();
        }

        public DataSet LD_estado_caso()
        {
            return L_D.LD_estado_caso();
        }

        //carga lista de subestados dependiendo del estado
        public DataSet L_D_subestado_caso(int id_proceso)
        {
            return L_D.L_D_subestado_caso(id_proceso);
        }

        // lista de las entidades por departamento y municipio
        public DataSet LD_entidad_x_dep_municipio(int id_departamento, int id_municipio)
        {
            return L_D.LD_entidad_x_dep_municipio(id_departamento, id_municipio);
        }


        //Lista de las ofertas por departamento, municipio y entidad
        public DataSet LD_oferta_dep_mun_entidad(int id_departamento, int id_municipio, int id_entidad)
        {
            return L_D.LD_oferta_dep_mun_entidad(id_departamento, id_municipio, id_entidad);
        }

        //Consulta el estado de la oferta en el reporte
        public DataSet LD_estado_oferta()
        {
            return L_D.LD_estado_oferta();
        }

        // Listado de los tipos de alcances de la entidad
        public DataSet LD_entidad_alcance()
        {
            return L_D.LD_entidad_alcance();
        }

        
        public DataSet LD_medida_programa(int id_marco)
        {
            return L_D.LD_medida_programa(id_marco);
        }

        public DataSet LD_detalle_componente(int id_componente)
        {
            return L_D.LD_detalle_componente(id_componente);
        }

        //componentes de la medida
        public DataSet LD_Componentes()
        {
            return L_D.LD_Componentes();
        }

        //detalle de los componentes de la medida
        public DataSet LD_Especificaciones(int id_componente)
        {
            return L_D.LD_Especificaciones(id_componente);
        }

        // lista de los modulos
        public DataSet RBL_Modulos(int id_modulo)
        {
            return L_D.RBL_Modulos(id_modulo);
        }

        public DataSet L_D_Modulo()
        {
            return L_D.L_D_Modulo();
        }

        // categoria de las preguntas
        public DataSet L_D_Campo()
        {
            return L_D.L_D_Campo();
        }

        
        public DataSet L_D_Sub_estados()
        {
            return L_D.L_D_Sub_estados();
        }

        
        //Listado de los tipos de documento
        public DataSet LD_Tipo_documento()
        {
            return L_D.LD_Tipo_documento();
        }

        //Listado de los tipos de documento de ryr
        public DataSet LD_Tipo_documento_ryr(int opcion)
        {
            return L_D.LD_Tipo_documento_ryr(opcion);
        }

        // lista desplegable de los estados del ruv
        public DataSet L_D_Estado_ruv()
        {
            // return L_D.L_D_Estado_ruv();
            return L_D.LD_Tipo_documento();
        }

        public DataSet RBL_Modulos_colectiva(int id_modulo)
        {
            return L_D.RBL_Modulos_colectiva(id_modulo);
        }

        //Listado tipo de sujeto colectiva
        public DataSet L_D_tipo_sujeto()
        {
            return L_D.L_D_tipo_sujeto();
        }

        //Listado de los tipos de contactos
        public DataSet L_D_Tipo_contacto()
        {
            return L_D.L_D_Tipo_contacto();
        }

        public DataSet L_D_Tipo_Contacto(int opcion)
        {
            return L_D.L_D_Tipo_Contacto(opcion);
        }

        // programa
        public DataSet LD_Programa_remision()
        {
            return L_D.LD_Programa_remision(); // TODO: FALTA DAO Y TABLA
        }

        // cargar los items de la lista departamentos
        public DataSet L_D_parametros_oferta()
        {
            return L_D.L_D_parametros_oferta();
        }

        // cargar los items de la lista departamentos
        public DataSet L_D_Estado_remision()
        {
            return L_D.L_D_Estado_remision();
        }

        public DataSet L_D_Opcion_tierras_choq(int opcion)
        {
            return L_D.L_D_Opcion_tierras_choq(opcion);
        }

        // cargar lugar territorial, departamento , municipios
        public DataSet L_D_Consulta_lugar(int opcion, int id_territorial, int id_departamento)
        {
            return L_D.L_D_Consulta_lugar(opcion, id_territorial, id_departamento);
        }

        //lista de tipo de parentesco o relacion familiar
        public DataSet LD_Tipo_parentesco()
        {
            return L_D.LD_Tipo_parentesco();
        }

        //lista de tipo de etnias
        public DataSet LD_Tipo_etnia()
        {
            return L_D.LD_Tipo_etnia();
        }

        //lista de tipo de etnias
        public DataSet LD_Tipo_resguardo()
        {
            return L_D.LD_Tipo_resguardo();
        }

        public DataSet L_D_id_tipo_solicitud1()
        {
            return L_D.L_D_id_tipo_solicitud1();
        }

        public DataSet L_D_id_area_misional1()
        {
            return L_D.L_D_id_area_misional1();
        }

        public DataSet L_D_id_tipo_requerimiento1(int SUB_ID_TIPO_SOLICITUD)
        {
            return L_D.L_D_id_tipo_requerimiento1(SUB_ID_TIPO_SOLICITUD);
        }

        //Listado perfil usuarios colectiva
        public DataSet L_D_Perfil()
        {
            return L_D.L_D_Perfil();
        }

        //Consulta los usuarios por perfil de colectiva
        public DataSet L_D_Usuarios(int id_perfil, int id_sujeto)
        {
            return L_D.L_D_Usuarios(id_perfil, id_sujeto);
        }

        //lista de tipo de rol de eventos
        public DataSet LD_Rol_evento()
        {
            return L_D.LD_Rol_evento();
        }

        //Listado tipo de sujeto colectiva
        public DataSet L_D_tipo_sujeto_detalle(int id_tipo_sujeto_colectiva_det)
        {
            return L_D.L_D_tipo_sujeto_detalle(id_tipo_sujeto_colectiva_det);
        }

        // cargar los items de la lista de despachos
        public DataSet L_D_Despacho(int id_municipio)
        {
            return L_D.L_D_Despacho(id_municipio);
        }

        // cargar los items de la lista de despachos
        public DataSet LD_Estado_proceso()
        {
            return L_D.LD_Estado_proceso();
        }

        // cargar los items de la lista de los roles de los procesos
        public DataSet L_D_rol_gv1()
        {
            return L_D.L_D_rol_gv1();
        }

        public DataSet LD_Tipo_archivo()
        {
            return L_D.LD_Tipo_archivo();
        }

        //Listado de usuarios activos
        public DataSet LD_Resposable()
        {
            return L_D.LD_Resposable();
        }

        //Listado de los usuarios listadores
        public DataSet L_D_Listador()
        {
            return L_D.L_D_Listador();
        }

        public DataSet LD_Estado_imagen()
        {
            return L_D.LD_Estado_imagen();
        }

        public DataSet LD_proceso_usuario(int id_usuario, int id_rol, int opcion)
        {
            return L_D.LD_proceso_usuario(id_usuario, id_rol, opcion);
        }

        

        public DataSet L_D_tipo_carta()
        {
            return L_D.L_D_tipo_carta();
        }

        public DataSet LD_Estado_Grupo_Fondo_Educacion()
        {
            return L_D.LD_Estado_Grupo_Fondo_Educacion();
        }

        public DataSet LD_Estado_Actividad_Fondo_Educacion()
        {
            return L_D.LD_Estado_Actividad_Fondo_Educacion();
        }

        public DataSet LD_Grupos_Fondo_Educacion(int IdGrupo, int IdUsuario)
        {
            return L_D.LD_Grupos_Fondo_Educacion(IdGrupo, IdUsuario);
        }

        public DataSet LD_Estado_Seguimiento_Actividad()
        {
            return L_D.LD_Estado_Seguimiento_Actividad();
        }

        public DataSet LD_Pregunta_Secreta(int intOpcion, Int32 intIdUsuario, Guid GUID, string strIdentificacion, Int16 intIdPreguntaSecreta, string strRespuestaSecreta)
        {
            return L_D.LD_Pregunta_Secreta(intOpcion, intIdUsuario, GUID, strIdentificacion, intIdPreguntaSecreta, strRespuestaSecreta);
        }

        // cargar los items de la lista de dependencia
        public DataSet LD_Dependencia(int id_dependencia, int opcion)
        {
            return L_D.LD_Dependencia(id_dependencia, opcion);
        }

        // cargar los items de la lista de dependencia
        public DataSet LD_Supervisor(int id_supervisor, int opcion)
        {
            return L_D.LD_Supervisor(id_supervisor, opcion);
        }

        // cargar los items de la lista de feria
        public DataSet LD_Feria()
        {
            return L_D.LD_Feria();
        }

        // cargar los items de la lista departamentos
        public DataSet L_D_Departamentos(int id_territorial)
        {
            return L_D.L_D_Departamentos(id_territorial);
        }

       

        public DataSet LD_Estado_RyR(int opcion)
        {
            return L_D.LD_Estado_RyR(opcion);
        }

        // cargar los items de la lista departamentos y municipios
        public DataSet L_D_Dep_Mun()
        {
            return L_D.L_D_Dep_Mun();
        }
        // cargar los items de la lista orientacion sexual
        public DataSet LD_OSexual()
        {
            return L_D.LD_OSexual();
        }
        // cargar los items de la lista identidad de genero
        public DataSet LD_IDGenero()
        {
            return L_D.LD_IDGenero();
        }

        // consulta el tipo de actividad
        public DataSet LD_Tipo_actividad()
        {
            return L_D.LD_Tipo_actividad();
        }

        // carga los tipos de detalle para proyecto pruductivo
        public DataSet LD_Tipo_actividad_proye_produ()
        {
            return L_D.Tipo_actividad_proye_produ();
        }

        public DataSet LD_Tipo_actividad2(int id_actividad_nombre, int opcion)
        {
            return L_D.LD_Tipo_actividad2(id_actividad_nombre, opcion);
        }

        // consulta el tipo de rol en la actividad
        public DataSet LD_Rol_responsable()
        {
            return L_D.LD_Rol_responsable();
        }

        // consulta el tipo de rol en la actividad, segun su parametrización y necesidad
        public DataSet LD_Rol_responsable2(int opcion)
        {
            return L_D.LD_Rol_responsable2(opcion);
        }

        // cargar los items de la lista municipios segun el departamento seleccionado para las actividades
        public DataSet L_D_Municipio_actividad(int id_departamento, int id_actividad)
        {
            return L_D.L_D_Municipio_actividad(id_departamento, id_actividad);
        }

        // consulta el los estados de los conceptos RyR
        public DataSet L_D_Estado_concepto(int opcion)
        {
            return L_D.L_D_Estado_concepto(opcion);
        }

        // consulta el estado del detalle de la actividad
        public DataSet LD_actividad_detalle_estado()
        {
            return L_D.LD_actividad_detalle_estado();
        }

        // consulta los dias de una actividad
        public DataSet LD_Dia_actividad(int id_actividad)
        {
            return L_D.LD_Dia_actividad(id_actividad);
        }

        // consulta los dias de una actividad
        public DataSet LD_Dia_actividad(int id_actividad, int opcion)
        {
            return L_D.LD_Dia_actividad(id_actividad, opcion);
        }

        //Listado de los tipos de archivo talleres de educacion finaciera
        public DataSet LD_Tipo_archivo(int id_proceso, int opcion)
        {
            return L_D.LD_Tipo_archivo(id_proceso, opcion);
        }

        // consulta el estadop de la actividad
        public DataSet LD_Actividad_estado()
        {
            return L_D.LD_Actividad_estado();
        }

        // consulta los nombres de la actividad
        public DataSet LD_Actividad_nombre(int id_dependencia, int opcion)
        {
            return L_D.LD_Actividad_nombre(id_dependencia, opcion);
        }

        // cargar los items de la lista departamentos
        public DataSet L_D_Usuario(int id_dependencia, int opcion)
        {
            return L_D.L_D_Usuario(id_dependencia, opcion);
        }

        public DataSet L_D_Entorno_ryr(int opcion)
        {
            return L_D.L_D_Entorno_ryr(opcion);
        }

        public DataSet L_D_intencion(int opcion)
        {
            return L_D.L_D_intencion(opcion);
        }


        public DataSet L_D_Modulo_tierras(int opcion) // paari
        {
            return L_D.L_D_Modulo_tierras(opcion);
        }

        public DataSet LD_Estado_civil(int opcion) // paari
        {
            return L_D.L_D_Modulo_tierras(opcion);
        }

        public DataSet LD_Estado_paari(int opcion) // paari
        {
            return L_D.LD_Estado_paari(opcion);
        }

        //Listado de los tipos de documento de ryr
        public DataSet LD_Tipo_documento_cys(int opcion)
        {
            return L_D.LD_Tipo_documento_cys(opcion);
        }

        public DataSet LD_Estado_Psicosocial(int opcion)
        {
            return L_D.LD_Estado_Psicosocial(opcion);
        }

        //listado para tipo de solicitudes
        public DataSet LD_Tipo_solicitud_scys()
        {
            return L_D.LD_Tipo_solicitud_scys();
        }

        // cargar los items de la lista productos
        public DataSet L_D_Producto()
        {
            return L_D.L_D_Producto();
        }

        // cargar los items de la lista sub productos
        public DataSet L_D_Sub_producto(int id_producto)
        {
            return L_D.L_D_Sub_producto(id_producto);
        }

        public DataSet LD_Estado_Parametrizacion(int id_parametrizacion, int opcion)
        {
            return L_D.LD_Estado_Parametrizacion(id_parametrizacion, opcion);
        }


        public DataSet LD_Tipo_actividad_enfoque()
        {
            return L_D.LD_Tipo_actividad_enfoque();
        }


        // consulta el tipo de rol en la actividad
        public DataSet LD_Rol_responsable_enfoque()
        {
            return L_D.LD_Rol_responsable_enfoque();
        }

        // cargar los items de la lista municipios segun el departamento y la territorial seleccionados para las actividades
        public DataSet L_D_Municipio_actividad_t(int id_territorial, int id_departamento, int id_actividad, int opcion)
        {
            return L_D.L_D_Municipio_actividad_t(id_territorial, id_departamento, id_actividad, opcion);
        }

        // Lista de socios estrategicos de linea de inversion vivienda
        public DataSet LD_Tipo_actividad_linea_vivienda()
        {
            return L_D.LD_Tipo_actividad_linea_vivienda();
        }

        public DataSet LD_Actividad_estado_jornadas(int opcion)
        {
            return L_D.LD_Actividad_estado_jornadas(opcion);
        }

        // cargar los items de la lista departamentos
        public DataSet L_D_Indicador(int opcion)
        {
            return L_D.L_D_Indicador(opcion);
        }

        // lista desplegables padres
        public DataSet L_D_Padre(int opcion)
        {
            return L_D.L_D_Padre(opcion);
        }

        #region SIGO
                
        // cargar los items de las listas para la consulta en SIGO
        public DataSet L_D_Consulta_items_sigo(int id_medida, int opcion)
        {
            return L_D.L_D_Consulta_items_sigo(id_medida, opcion);
        }


        #endregion



        #endregion

        
        #region AGENDA
                

        public DataSet Consultar_usuarios_por_supervisor(Usuario usuario, int opcion)
        {
            return usuarios.Consultar_usuarios_por_supervisor(usuario, opcion);
        }

        public int Administrador_asignaciones(Usuario usuario, int opcion)
        {
            return usuarios.Administrador_asignaciones(usuario, opcion);
        }

        
        #endregion

        #region OFERTA
               

        // cargar los items de la lista de zonas
        public DataSet L_D_Zona()
        {
            return L_D.L_D_Zona();
        }

        // cargar los items de la lista territorial
        public DataSet L_D_Territorial()
        {
            return L_D.L_D_Territorial();
        }
                

        public DataSet LD_TipoPersona()
        {
            return L_D.LD_TipoPersona();
        }


        
        #endregion

        
        #region SEGURIDAD - ADMINISTRAR USUARIOS DEL SISTEMA

        
        /// <summary>
        /// Permite administrar los usuarios
        /// </summary>
        /// <param name="login">Login del usuario a autenticar</param>
        /// <param name="pass">Password del usuario a autenticar</param>
        /// <param name="tipo">Tipo de usuario a autenticar</param>
        /// <returns>Los datos del usuario autenticado</returns>
        public int administrar_usuario(Usuario usuario, int opcion)
        {
            return usuarios.administrar_usuario(usuario, opcion);
        }

        public int administrar_sesiones(Usuario usuario, int opcion)
        {
            return usuarios.administrar_sesiones(usuario, opcion);
        }

        public DataSet activacion_usuario_sp(Usuario usuario, int opcion)
        {
            return usuarios.activacion_usuario_sp(usuario, opcion);
        }

        /// <summary>
        /// Permite consultar los usuarios
        /// </summary>
        /// <param name="login">Login del usuario a autenticar</param>
        /// <param name="pass">Password del usuario a autenticar</param>
        /// <param name="tipo">Tipo de usuario a autenticar</param>
        /// <returns>Los datos del usuario autenticado</returns>
        public DataSet administrar_usuario_ds(Usuario usuario, int opcion)
        {
            return usuarios.administrar_usuario_ds(usuario, opcion);
        }

        // BRAYAN HERREÑI  18-03-2019
        /// <summary>
        /// Permite consultar los ingresos en general
        /// </summary>
        /// <returns>Los datos del usuario autenticado</returns>
        public DataSet sp_reporte_usuarios(Usuario usuario, int opcion)
        {
            return usuarios.sp_reporte_usuarios(usuario, opcion);
        }

        // realiza la construccion de la nueva contraseña
        public String contraseña_randomica()
        {
            return pass_rand.contraseña_randomica();
        }

        /// <summary>
        /// Obtener todos los items o permisos del menú
        /// </summary>
        /// <returns>Colección de todos los permisos del menú</returns>
        public DataSet Permisos()
        {
            return permisos.Permisos();
        }

        /// <summary>
        /// Obtener los permisos de un tipo de usuario
        /// </summary>
        /// <param name="id_tipo_part">Identificador del tipo de usuario</param>
        /// <returns>Todos los permisos asociados a un tipo de usuario</returns>
        public DataSet permisos_tipo_usuario(int id_tipo_usuario)
        {
            return permisos.permisos_tipo_usuario(id_tipo_usuario);
        }

        /// <summary>
        /// Obtener los módulos del menú principal
        /// </summary>
        /// <returns>Los modulos asociados al menú principal</returns>
        public DataSet Permisos_modulo()
        {
            return permisos.Permisos_modulo();
        }

        /// Guardar los permisos de un tipo de usuario
        /// </summary>
        /// <param name="permisos">Colección de permisos asignados</param>
        public void Permisos_guardar(PermisoRol perms)
        {
            permisos.Permisos_guardar(perms);
        }

        /// <summary>
        /// Permite administrar los roles
        /// </summary>
        /// <param name="login">Login del usuario a autenticar</param>
        /// <param name="pass">Password del usuario a autenticar</param>
        /// <param name="tipo">Tipo de usuario a autenticar</param>
        /// <returns>Los datos del usuario autenticado</returns>
        public int administrar_roles(Usuario usuario, int opcion)
        {
            return usuarios.administrar_roles(usuario, opcion);
        }

        /// <summary>
        /// Permite administrar los roles
        /// </summary>
        /// <param name="login">Login del usuario a autenticar</param>
        /// <param name="pass">Password del usuario a autenticar</param>
        /// <param name="tipo">Tipo de usuario a autenticar</param>
        /// <returns>Los datos del usuario autenticado</returns>
        public DataSet administrar_roles_ds(Usuario usuario, int opcion)
        {
            return usuarios.administrar_roles_ds(usuario, opcion);
        }

        public int insert_permisos_usuario_uno(int opcion)
        {
            return permisos.insert_permisos_usuario_uno(opcion);
        }

        ///<summary>
        ///Obtener las url permitidas por participantes
        ///</summary>
        ///<param name = "id_tipo_part"> Identificación del participante </param>
        ///<returns>Lista de las url permitidas</returns>
        public DataTable getURLPermisos(string id_tipo_part, string urlPeticion)
        {
            return permisos.getURLPermisos(id_tipo_part, urlPeticion);
        }

        
        public DataSet administrar_sesion_duplicada(Usuario usuario, int opcion)
        {
            return usuarios.administrar_sesion_duplicada(usuario, opcion);
        }

        public DataSet administrar_ip_cambiada(Usuario usuario, int opcion)
        {
            return usuarios.administrar_ip_cambiada(usuario, opcion);
        }

        /// <summary>
        /// Brayan Herreño 31/07/2018
        /// </summary>
        /// <returns>Este dataset se usara para Indicadores_ingresos_maariv</returns>
        public DataSet Indicadores_ingresos_maariv_data(Usuario usuario, int opcion)
        {
            return usuarios.Indicadores_ingresos_maariv_data(usuario, opcion);
        }

        #endregion

        #region ENCRIPCION

        public string encriptacion(string cadenaLimpia, string passwordEncripcion)
        {
            return daoEnc.encriptacion(cadenaLimpia, passwordEncripcion);
        }

        public string Encriptar(string cadenaLimpia, string passwordEncripcion)
        {
            return daoEnc.Encriptar(cadenaLimpia, passwordEncripcion);
        }

        public string Desencriptar(string cadenaLimpia, string passwordEncripcion)
        {
            return daoEnc.Desencriptar(cadenaLimpia, passwordEncripcion);
        }



        #endregion

        #region LOG DE AUDITORIA

        public void registrarLog(string operacion)
        {
            //daoLog.registrarLog(operacion);

        }

        
        #endregion

        #region WEB SERVICES

        
        public DataSet validar_ws(string NOMBRE_WS, string USUARIO, string PASSWORD)
        {
            return validar_ws(NOMBRE_WS, USUARIO, PASSWORD);
        }

        
        #endregion

        
        #region COLECTIVA

        //Administra el sujeto colectivo
        public int Administrar_sujeto(Sujeto_colectiva sujeto_colectiva, int opcion)
        {
            return colectiva.Administrar_sujeto(sujeto_colectiva, opcion);
        }

        // Consulto el sujeto colectivo
        public DataSet Consultar_sujeto(Sujeto_colectiva sujeto_colectiva, int opcion)
        {
            return colectiva.Consultar_sujeto(sujeto_colectiva, opcion);
        }

        // Consulta la bandeja de los sujetos colectivos
        public DataSet Consultar_bandeja_colectiva(Sujeto_colectiva sujeto_colectiva, int opcion)
        {
            return colectiva.Consultar_bandeja_colectiva(sujeto_colectiva, opcion);
        }

        public DataSet Consultar_directorio(Sujeto_colectiva sujeto_colectiva)
        {
            return colectiva.Consultar_directorio(sujeto_colectiva);
        }

        public int Administrar_directorio(Sujeto_colectiva sujeto_colectiva, int opcion)
        {
            return colectiva.Administrar_directorio(sujeto_colectiva, opcion);
        }

        //Consulta la asignacion de los sujetos colectivos            
        public DataSet Consultar_asignacion(Sujeto_colectiva sujeto_colectiva)
        {
            return colectiva.Consultar_asignacion(sujeto_colectiva);
        }

        //Administra la asignacion del sujeto colectivo
        public int Administrar_asignacion_sujeto(Sujeto_colectiva sujeto_colectiva, int opcion)
        {
            return colectiva.Administrar_asignacion_sujeto(sujeto_colectiva, opcion);
        }

        // Consulta las preguntas segun el tipo de sujeto y el perfil
        public DataSet Consultar_tipo_preguntas(Sujeto_colectiva sujeto_colectiva)
        {
            return colectiva.Consultar_tipo_preguntas(sujeto_colectiva);
        }

                
        #endregion

        
        #region PERSONAS

        public DataSet consultar_personas(Persona persona, int opcion)
        {
            return Personas.consultar_personas(persona, opcion);
        }

        public int administrar_personas(Persona persona, int opcion)
        {
            return Personas.administrar_personas(persona, opcion);
        }

        // Permite consultar las personas para agregar a un proceso
        public DataSet consultar_personas_proceso(Persona persona, int opcion)
        {
            return Personas.consultar_personas_proceso(persona, opcion);
        }

        public DataSet consulta_hechos_victimizantes_persona(Persona persona, int opcion)
        {
            return Personas.consulta_hechos_victimizantes_persona(persona, opcion);
        }


        public int Administrar_hvictimizante_persona(Persona persona, int opcion)
        {
            return Personas.Administrar_hvictimizante_persona(persona, opcion);
        }

        #endregion

        #region ACTIVIDAD

            // permite administrar las actividades
            public int Administrar_actividad(Actividad actividad, int opcion)
            {
                return Actividades.Administrar_actividad(actividad, opcion);
            }

            // permite consultar la actividad
            public DataSet Consulta_actividad(Actividad actividad, Persona persona, int opcion)
            {
                return Actividades.Consulta_actividad(actividad, persona, opcion);
            }

            public DataSet Consulta_fases_colectiva(Sujeto_colectiva sujeto_colectiva, int opcion)
            {
                return Actividades.Consulta_fases_colectiva(sujeto_colectiva, opcion);
            }

        #endregion

       
        #region ACTIVIDAD_DETALLE

        // permite administrar los detalles de las actividades
        public int Administrar_actividad_detalle(Actividad_detalle actividad_detalle, int opcion)
        {
            return Actividad_detalle.Administrar_actividad_detalle(actividad_detalle, opcion);
        }

        // permite consultar el detalle de la actividad
        public DataSet Consulta_actividad_detalle(Actividad_detalle actividad_detalle, int opcion)
        {
            return Actividad_detalle.Consulta_actividad_detalle(actividad_detalle, opcion);
        }

        
        // permite Administrar los costos de la actividad
        public int Administrar_actividad_dia_costo(actividad_dia_costo actividad_dia_costo, int opcion)
        {
            return Actividad_detalle.Administrar_actividad_dia_costo(actividad_dia_costo, opcion);
        }

        // permite consulta los costos de la actividad
        public DataSet Consultar_actividad_dia_costo(actividad_dia_costo actividad_dia_costo, int opcion)
        {
            return Actividad_detalle.Consultar_actividad_dia_costo(actividad_dia_costo, opcion);
        }

        // permite Administrar las bhitacoras de la actividad
        public int Administrar_actividad_dia_bitacora(Actividad_dia_bitacora actividad_dia_bitacora, int opcion)
        {
            return Actividad_detalle.Administrar_actividad_dia_bitacora(actividad_dia_bitacora, opcion);
        }

        // permite consultar las bhitacoras de la actividad
        public DataSet Consultar_actividad_dia_bitacora(Actividad_dia_bitacora actividad_dia_bitacora, int opcion)
        {
            return Actividad_detalle.Consultar_actividad_dia_bitacora(actividad_dia_bitacora, opcion);
        }

        #endregion

        #region ACTIVIDAD_RESPONSABLE

        // permite administrar los responsables de las actividades
        public int Administrar_actividad_responsable(Actividad_responsable actividad_responsable, int opcion)
        {
            return Actividad_Responsable.Administrar_actividad_responsable(actividad_responsable, opcion);
        }

        // permite consultar el responsable de la actividad
        public DataSet Consulta_actividad_responsable(Actividad_responsable actividad_responsable, int opcion)
        {
            return Actividad_Responsable.Consulta_actividad_responsable(actividad_responsable, opcion);
        }

        #endregion

        #region ACTIVIDAD_COBERTURA

        // permite administrar los responsables de las actividades
        public int Administrar_actividad_cobertura(Actividad_cobertura actividad_cobertura, int opcion)
        {
            return Actividad_Cobertura.Administrar_actividad_cobertura(actividad_cobertura, opcion);
        }

        // permite consultar la cobertura de la actividad
        public DataSet Consulta_actividad_cobertura(Actividad_cobertura actividad_cobertura, int opcion)
        {
            return Actividad_Cobertura.Consulta_actividad_cobertura(actividad_cobertura, opcion);
        }

        #endregion

        #region ACTIVIDAD_DIA

        // permite administrar los responsables de las actividades
        public int Administrar_actividad_dia_Colectiva(Actividad_dia actividad_dia, int opcion)
        {
            return Actividad_Dia.Administrar_actividad_dia_Colectiva(actividad_dia, opcion);
        }

        public DataSet consulta_tipo_medida()
        {
            return Actividad_Dia.consulta_tipo_medida();
        }

        // permite administrar los responsables de las actividades
        public int Administrar_actividad_producto(Actividad_producto actividad_producto, int opcion)
        {
            return Actividad_Dia.Administrar_actividad_producto(actividad_producto, opcion);
        }

        // permite administrar los responsables de las actividades
        public int Administrar_actividad_dia(Actividad_dia actividad_dia, int opcion)
        {
            return Actividad_Dia.Administrar_actividad_dia(actividad_dia, opcion);
        }

        // permite consultar la consulta dias actividad
        public DataSet consulta_actividad_dia(Actividad_dia actividad_dia, int opcion)
        {
            return Actividad_Dia.consulta_actividad_dia(actividad_dia, opcion);
        }

        // permite consultar la consulta los documentos obligatorios para cada proceso
        public DataSet Consulta_documentos_obligatorios(int id_nombre_actividad, int opcion)
        {
            return Actividad_Dia.Consulta_documentos_obligatorios(id_nombre_actividad, opcion);
        }

        // consulta los dias de una actividad
        public DataSet consulta_tipos_material(int id_nombre_actividad, int opcion)
        {
            return Actividad_Dia.consulta_tipos_material(id_nombre_actividad, opcion);
        }

        // permite administrar las personas, la asistencia y el material o accion aplicada a la persona
        public int administrar_asociar_personas(Actividad_dia actividad_dia, Persona persona, int opcion)
        {
            return Actividad_Dia.administrar_asociar_personas(actividad_dia, persona, opcion);
        }

        // permite consultar las personas, la asistencia y el material o accion aplicada a la persona
        public DataSet consultar_persona_actividad(Actividad_dia actividad_dia, Persona persona, int opcion)
        {
            return Actividad_Dia.consultar_persona_actividad(actividad_dia, persona, opcion);
        }

        //permite hacer la consulta de personas que ya han participado en las seciones anteriores
        public DataSet asistencia_persona_actividad(Actividad_dia actividad_dia, int opcion)
        {
            return Actividad_Dia.asistencia_persona_actividad(actividad_dia, opcion);
        }

        //consultar los test del PAE
        public DataSet consulta_actividad_dia_pae(Actividad_dia actividad_dia)
        {
            return Actividad_Dia.consulta_actividad_dia_pae(actividad_dia);
        }

        //crea los test
        public int Administrar_test(Actividad_dia actividad_dia, int opcion)
        {
            return Actividad_Dia.Administrar_test(actividad_dia, opcion);
        }

        #endregion

        #region ACTIVIDAD_ARCHIVO

        public DataSet consultar_actividad_archivos(Adjuntar_archivos_act adjuntar_archivos, int opcion)
        {
            return archivos_act.consultar_actividad_archivos(adjuntar_archivos, opcion);
        }

        public DataSet consultar_actividad_archivos_obligatorios(Adjuntar_archivos_act adjuntar_archivos, int opcion)
        {
            return archivos_act.consultar_actividad_archivos_obligatorios(adjuntar_archivos, opcion);
        }
        

        public int Administrar_actividad_archivos(Adjuntar_archivos_act adjuntar_archivos, int opcion)
        {
            return archivos_act.Administrar_actividad_archivos(adjuntar_archivos, opcion);
        }

        #endregion

        #region ACTIVIDAD CALENDARIO
        
        // consulta las actividades de un evento
        public DataSet 
            Consulta_actividad_calendario(Actividad actividad, Persona persona, int opcion)
        {
            return Actividades.Consulta_actividad_calendario(actividad, persona, opcion);
        }
        
        #endregion

        #region ACTIVIDAD REPORTES

            // permite consultar los reportes de la actividad
            public DataSet reporte_actividad_plan_accion(Actividad actividad, int opcion)
            {
                return Actividades.reporte_actividad_plan_accion(actividad, opcion);
            }

            // permite consultar la actividad
            public DataSet Consulta_mopdulo_m(Actividad actividad, Persona persona, int opcion)
            {
                return Actividades.Consulta_mopdulo_m(actividad, persona, opcion);
            }
        
        #endregion

        #region ACTIVIDAD CARGUE MASIVO PERSONAS  

        // permite administrar los datos del archivo a procesar
        public DataSet Adm_actividad_cargue_masivo(DataTable DTable, int opcion)
        {
            return Actividades.Adm_actividad_cargue_masivo(DTable, opcion);
        }

        #endregion

        
        #region CREAR MENSAJES

        public int Administrar_creacion_mensajes(creacion_mensajes mensajes, int opcion)
        {
            return mensaje.Administrar_creacion_mensajes(mensajes, opcion);
        }

        //Cambio alejandro Moreno 04/09/2018
        public DataSet Buscar_mensajes(creacion_mensajes mensajes)
        {
            return mensaje.Buscar_mensajes(mensajes);
        }

        public int Administrar_calificacion(creacion_mensajes mensajes, int opcion)
        {
            return mensaje.Administrar_calificacion(mensajes, opcion);
        }

        public DataSet buscar_mensajes_fecha(creacion_mensajes mensajes)
        {
            return mensaje.buscar_mensajes_fecha(mensajes);
        }

        public DataSet buscar_mensajes_fecha_grilla(creacion_mensajes mensajes)
        {
            return mensaje.buscar_mensajes_fecha_grilla(mensajes);
        }

        public DataSet Administrar_pop_up(creacion_mensajes mensajes, int opcion)
        {
            return mensaje.Administrar_pop_up(mensajes, opcion);
        }

        #endregion

                
        #region REPORTES

            /**
             * Cambio alejandro para reporte de colectiva en sp_reporte_colectiva 
             */
            // Reporte estado colectiva
            public DataSet reporte_colectiva(Sujeto_colectiva sujeto_colectiva, int opcion)
            {
                return colectiva.reporte_colectiva(sujeto_colectiva, opcion);
            }
        /**
        * Fin cambio alejandro
        */

        #endregion

        
        #region MGA

        public DataSet ListaParametrosMGA()
        {
            return daoMGA.ListaParametros();
        }

        public DataSet DatosParametrosMGA(int idParam)
        {
            return daoMGA.ListaParametrosById(idParam);
        }

        public DataRow DatosParametro(int idParam)
        {
            return daoMGA.DatosParametro(idParam);
        }

        public DataSet ListaValoresParametroTabla(string param)
        {
            return daoMGA.ListaValoresParametroTabla(param);
        }

        public DataSet ListaValoresParametroTablaSujeto(string param, int param2)
        {
            return daoMGA.ListaValoresParametroTablaSujeto(param, param2);
        }

        public DataSet ListaValoresParametroTablaId(string param, string tablaMain, int idMain)
        {
            return daoMGA.ListaValoresParametroTablaId(param, tablaMain, idMain);
        }

        public int InsertarValorParametro(string tabla, string valor, bool activo, bool depen, int idDepen, bool sujeto, int idSujeto)
        {
            return daoMGA.InsertarValorParametro(tabla, valor, activo, depen, idDepen, sujeto, idSujeto);
        }

        public int InsertarValorParametroProducto(int idValor, string valor, bool activo, int idDepen, string descripcion, string medido, string indicador, string medida)
        {
            return daoMGA.InsertarValorParametroProducto(idValor, valor, activo, idDepen, descripcion, medido, indicador, medida);
        }

        public int ActualizarValorParametro(string tabla, string tablaDep, int idValor, string valor, bool activo, bool depen, int idDepen, bool sujeto, int idSujeto)
        {
            return daoMGA.ActualizarValorParametro(tabla, tablaDep, idValor, valor, activo, depen, idDepen, sujeto, idSujeto);
        }

        public int EliminarValorParametro(string tabla, int idValor)
        {
            return daoMGA.EliminarValorParametro(tabla, idValor);
        }

        public int InsertarDatosBasicosPIRC(int idSujeto, int idTipoSujeto, string nombreSujeto, string nit, int idDT, int idDept, int idMun, DateTime? fecha)
        {
            return daoMGA.InsertarDatosBasicosPIRC(idSujeto, idTipoSujeto, nombreSujeto, nit, idDT, idDept, idMun, fecha);
        }

        public int EliminarParametrosPIRC(int idSujeto, string param)
        {
            return daoMGA.EliminarParametrosPIRC(idSujeto, param);
        }

        public int InsertarParametrosPIRC(int idSujeto, int idParam, string param)
        {
            return daoMGA.InsertarParametrosPIRC(idSujeto, idParam, param);
        }

        public DataSet ListaParametrosPIRC(int idSujeto, string param)
        {
            return daoMGA.ListaParametrosPIRC(idSujeto, param);
        }

        public int InsertarAnalisisPoblacionPIRC(int idSujeto, string pobAfecQuienes, string pobAfecCarac, int pobAfecCantidad, string pobAfectUbica
            , string pobObjQuienes, string pobObjCarac, int pobObjCantidad, string pobObjtUbica)
        {
            return daoMGA.InsertarAnalisisPoblacionPIRC(idSujeto, pobAfecQuienes, pobAfecCarac, pobAfecCantidad, pobAfectUbica
            , pobObjQuienes, pobObjCarac, pobObjCantidad, pobObjtUbica);
        }

        public DataSet ObtenerAnalisisPoblacionPIRC(int idSujeto)
        {
            return daoMGA.ObtenerAnalisisPoblacionPIRC(idSujeto);
        }

        public DataSet ObtenerBeneficiosPIRC(int idSujeto)
        {
            return daoMGA.ObtenerBeneficiosPIRC(idSujeto);
        }

        public int InsertarBeneficiosPIRC(int idSujeto, string nombreBene, string descripcionBene)
        {
            return daoMGA.InsertarBeneficiosPIRC(idSujeto, nombreBene, descripcionBene);
        }

        public int EliminarBeneficiosPIRC(int idSujeto)
        {
            return daoMGA.EliminarBeneficiosPIRC(idSujeto);
        }

        public DataSet ObtenerDatosProducto(int idProducto)
        {
            return daoMGA.ObtenerDatosProducto(idProducto);
        }

        public DataSet ObtenerDatosActividadesProductosPIRC(int idProducto)
        {
            return daoMGA.ObtenerDatosActividadesProductosPIRC(idProducto);
        }

        public DataSet ObtenerDatosProductosPIRC(int idAtributo)
        {
            return daoMGA.ObtenerDatosProductosPIRC(idAtributo);
        }

        public DataSet ObtenerDatosAtributosPIRC(int idSujeto)
        {
            return daoMGA.ObtenerDatosAtributosPIRC(idSujeto);
        }

        public DataSet InsertarActividadesProductoPIRC(int idActividad, int idProducto, int idClasificacion, int idEtapa, string actividades, string descripcion, bool ruta
            , decimal costo1, decimal costo2, decimal costo3, decimal costot)
        {
            return daoMGA.InsertarActividadesProductoPIRC(idActividad, idProducto, idClasificacion, idEtapa, actividades, descripcion, ruta, costo1, costo2, costo3, costot);
        }

        public DataSet InsertarProductoAtributoPIRC(int idAtributo, int idProducto, decimal meta, string justificacion)
        {
            return daoMGA.InsertarProductoAtributoPIRC(idAtributo, idProducto, meta, justificacion);
        }

        public DataSet InsertarAtributoPIRC(int idSujeto, int idObjetivo, string objetivo, string atributo, int idAtributo)
        {
            return daoMGA.InsertarAtributoPIRC(idSujeto, idObjetivo, objetivo, atributo, idAtributo);
        }

        public int EliminarActividadesPIRC(int idActividad)
        {
            return daoMGA.EliminarActividadesPIRC(idActividad);
        }

        public int EliminarProductosPIRC(int idProducto)
        {
            return daoMGA.EliminarProductosPIRC(idProducto);
        }

        public int EliminarInvolucradosPIRC(int idSujeto)
        {
            return daoMGA.EliminarInvolucradosPIRC(idSujeto);
        }

        public int InsertarInvolucradoPIRC(int idSujeto, int idTipoActor, string tipoActor, string nombreActor, int idRolActor, string rolActor, string interesActor, int idInfluencia, string influencia
            , string estrategia, string contribucion)
        {
            return daoMGA.InsertarInvolucradoPIRC(idSujeto, idTipoActor, tipoActor, nombreActor, idRolActor, rolActor, interesActor, idInfluencia, influencia, estrategia, contribucion);
        }

        public DataSet ObtenerInvolucradosPIRC(int idSujeto)
        {
            return daoMGA.ObtenerInvolucradosPIRC(idSujeto);
        }

        public int InsertarInvolucradoConcertacionPIRC(int idSujeto, string concertacion)
        {
            return daoMGA.InsertarInvolucradoConcertacionPIRC(idSujeto, concertacion);
        }

        public DataSet ObtenerInvolucradosConcertacionPIRC(int idSujeto)
        {
            return daoMGA.ObtenerInvolucradosConcertacionPIRC(idSujeto);
        }

        public int EliminarRiesgosObjetivoGeneralPIRC(int idSujeto)
        {
            return daoMGA.EliminarRiesgosObjetivoGeneralPIRC(idSujeto);
        }

        public int EliminarRiesgosProductosPIRC(int idSujeto)
        {
            return daoMGA.EliminarRiesgosProductosPIRC(idSujeto);
        }

        public int EliminarRiesgosActividadesPIRC(int idSujeto)
        {
            return daoMGA.EliminarRiesgosActividadesPIRC(idSujeto);
        }

        public DataSet ObtenerRiesgosActividadesPIRC(int idSujeto)
        {
            return daoMGA.ObtenerRiesgosActividadesPIRC(idSujeto);
        }

        public DataSet ObtenerRiesgosProductosPIRC(int idSujeto)
        {
            return daoMGA.ObtenerRiesgosProductosPIRC(idSujeto);
        }

        public DataSet ObtenerRiesgosObjGralPIRC(int idSujeto)
        {
            return daoMGA.ObtenerRiesgosObjGralPIRC(idSujeto);
        }

        public int InsertarRiesgoActividadPIRC(int idSujeto, int idActividadCV, string actividadCV, string descripcion, int idTipoRiesgo, string tipoRiesgo, int idProbabilidad, string probabilidad
            , int idImpacto, string impacto, string efecto, string medidas)
        {
            return daoMGA.InsertarRiesgoActividadPIRC(idSujeto, idActividadCV, actividadCV, descripcion, idTipoRiesgo, tipoRiesgo, idProbabilidad, probabilidad, idImpacto, impacto, efecto, medidas);
        }

        public int InsertarRiesgoProductoPIRC(int idSujeto, int idProductoCV, string productoCV, string descripcion, int idTipoRiesgo, string tipoRiesgo, int idProbabilidad, string probabilidad
            , int idImpacto, string impacto, string efecto, string medidas)
        {
            return daoMGA.InsertarRiesgoProductoPIRC(idSujeto, idProductoCV, productoCV, descripcion, idTipoRiesgo, tipoRiesgo, idProbabilidad, probabilidad, idImpacto, impacto, efecto, medidas);
        }

        public int InsertarRiesgoObjGralPIRC(int idSujeto, string objetivoGral, string descripcion, int idTipoRiesgo, string tipoRiesgo, int idProbabilidad, string probabilidad
            , int idImpacto, string impacto, string efecto, string medidas)
        {
            return daoMGA.InsertarRiesgoObjGralPIRC(idSujeto, objetivoGral, descripcion, idTipoRiesgo, tipoRiesgo, idProbabilidad, probabilidad, idImpacto, impacto, efecto, medidas);
        }

        public DataSet ObtenerIndicadoresSeguimientoProductosPIRC(int idSujeto)
        {
            return daoMGA.ObtenerIndicadoresSeguimientoProductosPIRC(idSujeto);
        }

        public DataSet ObtenerIndicadoresSeguimientoActividadesPIRC(int idSujeto)
        {
            return daoMGA.ObtenerIndicadoresSeguimientoActividadesPIRC(idSujeto);
        }

        public int InsertarIndicadorSeguimientoActividadPIRC(int idSujeto, int idActividadCV, string actividad, int idIndicador, string indicador, string medido, string descripcion
            , string medida, decimal costoTotal, decimal costo1, decimal costo2, decimal costo3, decimal anno1, decimal anno2, decimal anno3, int idTipoFuente, string tipoFuente, string fuente)
        {
            return daoMGA.InsertarIndicadorSeguimientoActividadPIRC(idSujeto, idActividadCV, actividad, idIndicador, indicador, medido, descripcion, medida, costoTotal, costo1, costo2, costo3, anno1, anno2, anno3, idTipoFuente, tipoFuente, fuente);
        }

        public int InsertarIndicadorSeguimientoProductoPIRC(int idSujeto, int idProductoCV, int idProducto, string producto, string indicador, string medido, string descripcion
            , string medida, decimal metaTotal, decimal costo1, decimal costo2, decimal costo3, decimal anno1, decimal anno2, decimal anno3, int idTipoFuente, string tipoFuente, string fuente)
        {
            return daoMGA.InsertarIndicadorSeguimientoProductoPIRC(idSujeto, idProductoCV, idProducto, producto, indicador, medido, descripcion, medida, metaTotal, costo1, costo2, costo3, anno1, anno2, anno3, idTipoFuente, tipoFuente, fuente);
        }

        public int EliminarCronogramaTareasActividadesPIRC(int idSujeto)
        {
            return daoMGA.EliminarCronogramaTareasActividadesPIRC(idSujeto);
        }

        public DataSet ObtenerCronogramaTareasActividadesPIRC(int idSujeto)
        {
            return daoMGA.ObtenerCronogramaTareasActividadesPIRC(idSujeto);
        }

        public int InsertarCronogramaTareasActividadesPIRC(int idSujeto, int idActividadCV, string tarea, string responsable
            , bool E1, bool F1, bool M1, bool A1, bool MY1, bool J1, bool JL1, bool AG1, bool S1, bool O1, bool N1, bool D1
            , bool E2, bool F2, bool M2, bool A2, bool MY2, bool J2, bool JL2, bool AG2, bool S2, bool O2, bool N2, bool D2
            , bool E3, bool F3, bool M3, bool A3, bool MY3, bool J3, bool JL3, bool AG3, bool S3, bool O3, bool N3, bool D3
            , DateTime? fechaIni1, DateTime? fechaFin1, DateTime? fechaIni2, DateTime? fechaFin2, DateTime? fechaIni3, DateTime? fechaFin3)
        {
            return daoMGA.InsertarCronogramaTareasActividadesPIRC(idSujeto, idActividadCV, tarea, responsable
                , E1, F1, M1, A1, MY1, J1, JL1, AG1, S1, O1, N1, D1
                , E2, F2, M2, A2, MY2, J2, JL2, AG2, S2, O2, N2, D2
                , E3, F3, M3, A3, MY3, J3, JL3, AG3, S3, O3, N3, D3
                , fechaIni1, fechaFin1, fechaIni2, fechaFin2, fechaIni3, fechaFin3);
        }

        public DataSet ObtenerResumenProductosPIRC(int idSujeto)
        {
            return daoMGA.ObtenerResumenProductosPIRC(idSujeto);
        }

        public DataSet ObtenerResumenActividadesPIRC(int idSujeto)
        {
            return daoMGA.ObtenerResumenActividadesPIRC(idSujeto);
        }

        public int InsertarResumenProductoPIRC(int idSujeto, int idProductoCV, string supuestos)
        {
            return daoMGA.InsertarResumenProductoPIRC(idSujeto, idProductoCV, supuestos);
        }

        public int InsertarResumenActividadPIRC(int idSujeto, int idActividadCV, string supuestos)
        {
            return daoMGA.InsertarResumenActividadPIRC(idSujeto, idActividadCV, supuestos);
        }

        public int InsertarDatosPDFPIRC(int idSujeto, string problema, string objetivo, string poblacion, string localizacion, string aspEstrategico, string aspTecnico
            , string aspFinan, string aspSost, string aspPol, string implicaciones, string beneficios, string profRC, string profPsico, string profSatis, string profRehab
            , string profGaran, string profRestit, string profRevTecnica, string aspSoc, string aspLegal)
        {
            return daoMGA.InsertarDatosPDFPIRC(idSujeto, problema, objetivo, poblacion, localizacion, aspEstrategico, aspTecnico, aspFinan, aspSost, aspPol, implicaciones,
                beneficios, profRC, profPsico, profSatis, profRehab, profGaran, profRestit, profRevTecnica, aspSoc, aspLegal);
        }

        public DataSet ObtenerDatosPDFPIRC(int idSujeto)
        {
            return daoMGA.ObtenerDatosPDFPIRC(idSujeto);
        }

        public DataSet ObtenerDatosSujetoPIRC(int idSujeto)
        {
            return daoMGA.ObtenerDatosSujetoPIRC(idSujeto);
        }

        public DataSet ListaMedidasProductos()
        {
            return daoMGA.ListaMedidasProductos();
        }

        public DataSet ObtenerDatosReporteProductosMedida(string medida, int idSujeto)
        {
            return daoMGA.ObtenerDatosReporteProductosMedida(medida, idSujeto);
        }

        public DataSet ObtenerDatosReporteCostoTipoActividad(int idSujeto)
        {
            return daoMGA.ObtenerDatosReporteCostoTipoActividad(idSujeto);
        }

        #endregion

        
        public DataSet administrar_acti_dia_encuesta_solucion(Actividad_dia_encuesta_solucion ADES, int opcion)
        {
            return DAOADES.administrar_acti_dia_encuesta_solucion(ADES, opcion);
        }

        
        public DataSet actividad_dia_encuesta_pregunta(Actividad_dia_encuesta_pregunta ADEP, int opcion)
        {
            return DAOADEP.actividad_dia_encuesta_pregunta(ADEP, opcion);
        }



        public DataSet Consulta_actividad_2(Actividad actividad, Persona persona, int opcion)
            {
                return Actividades.Consulta_actividad_2(actividad, persona, opcion);
            }


        
        public DataSet actividad_dia_encuesta_respuesta_ultima(Actividad_dia_encuesta_pregunta ADEP, int opcion)
        {
            return DAOADEP.actividad_dia_encuesta_respuesta_utlima(ADEP, opcion);
        }

        
        #region CONTACTOS COLECTIVA

        public int Administrar_Contactos(Actividad actividad, int opcion)
        {
            return Actividades.Administrar_Contactos(actividad, opcion);
        }

        #endregion


        #region DESARROLLO FICHA CARACTERIZACION

        public DataSet Get_Comunidad(int idComunidad)
        {
            return comunitario.Get_Comunidad(idComunidad);
        }
        public DataSet Get_Personas_Comunidad(int idComunidad)
        {
            return comunitario.Get_Personas_Comunidad(idComunidad);
        }

        public void Set_Comunidad(List<SqlParameter> Parametros)
        {
            comunitario.Set_Comunidad(Parametros);
        }
        public void Set_Personas_Comunidad(List<SqlParameter> Parametros)
        {
            comunitario.Set_Personas_Comunidad(Parametros);
        }

        #endregion

        #region DESARROLLO PLAN RYR
        public DataSet Get_Plan_RyR(int idComunidad)
        {
            return comunitario.Get_Plan_RyR(idComunidad);
        }
        public DataSet GetEstadosPlanRyR()
        {
            return comunitario.Get_Estado_Plan_RyR();
        }

        public DataSet Get_Entorno()
        {
            return comunitario.Get_Entorno();
        }
        public void Set_Plan_RyR(List<SqlParameter> Parametros)
        {
            comunitario.Set_Plan_RyR(Parametros);
        }

        public DataSet Get_Necesidades_Comunidad(int idComunidad)
        {
            return comunitario.Get_Necesidades_Comunidad(idComunidad);
        }
        public void Set_Necesidad_Comunidad(List<SqlParameter> Parametros)
        {
            comunitario.Set_Necesidad_Comunidad(Parametros);
        }

        public DataSet Get_Evidencia(List<SqlParameter> Parametros)
        {
            return comunitario.Get_Evidencia(Parametros);
        }
        #endregion


        #region DESARROLLO RUTA COMUNITARIA  RYR
        public DataSet GetPlanTrasladoPorComunidad(int idComunidad)
        {
            return L_D.LD_PlanTrasladoPorComunidad(idComunidad);
        }
        public DataSet GetTodasEntidadesRutaComunitaria()
        {
            return L_D.LD_Entidades_Ruta_Comunitaria();
        }
        public int LD_Insertar_plan_acción_traslado_Ruta_Comunitaria(int idComunidad, int id_MunSalida, int idMunLlegada, int idEntornoSalida, int idEntornoLlegada, string corregimmientoSalida, string corregimientoLlegada, DateTime fechaInicio, DateTime fechaLlegada, int idUsuario)
        {
            return L_D.LD_Insertar_plan_acción_traslado_Ruta_Comunitaria(idComunidad,id_MunSalida, idMunLlegada, idEntornoSalida, idEntornoLlegada, corregimmientoSalida, corregimientoLlegada,  fechaInicio,  fechaLlegada, idUsuario);
        }
        public bool LD_Insertar_plan_acción_traslado_entidad_Ruta_Comunitaria(int idPlan, int idEntidad, int idUsuario)
        {
            return L_D.LD_Insertar_plan_acción_traslado_entidad_ruta_comunitaria(idPlan, idEntidad , idUsuario);
        }
        public bool LD_Eliminar_plan_acción_traslado_entidad_Ruta_Comunitaria(int idPlan, int idEntidad)
        {
            return L_D.LD_Eliminar_plan_acción_traslado_entidad_ruta_comunitaria(idPlan, idEntidad);
        }
        public bool LD_Insertar_plan_acción_traslado_categoria_ruta_comunitaria(int idCategoria, int idPlan, int idComuidad, string resultado, string acciones, string observaciones, int idUsuario)
        {
            return L_D.LD_Insertar_plan_acción_traslado_categoria_ruta_comunitaria(idCategoria, idPlan,  idComuidad,  resultado,  acciones,  observaciones, idUsuario);
        }
        public bool LD_Actualizar_plan_acción_traslado_para_balance_Ruta_Comunitaria(int idComunidad, int idPlan, int idDt, string profesional, string correo, DateTime fechaSSV, int idUsuario)
        {
            return L_D.LD_Actualizar_plan_acción_traslado_para_balance_Ruta_Comunitaria( idComunidad,  idPlan,  idDt,  profesional,  correo,  fechaSSV,  idUsuario);
        }
        public bool LD_Insertar_plan_acción_traslado_categoria_entidad_Ruta_Comunitaria(int idPlan, int idEntidad, int idCategoria, int idUsuario)
        {
            return L_D.LD_Insertar_plan_acción_traslado_Categorizacion_entidad_ruta_comunitaria(idPlan, idEntidad, idCategoria, idUsuario);
        }
        public bool LD_Eliminar_plan_acción_traslado_categoria_entidad_Ruta_Comunitaria(int idPlan, int idEntidad, int idCategoria)
        {
            return L_D.LD_Eliminar_plan_acción_traslado_caracterizacion_entidad_ruta_comunitaria(idPlan, idEntidad, idCategoria);
        }
        public bool LD_Eliminar_plan_acción_traslado_balance_traslado_Ruta_Comunitaria(int id)
        {
            return L_D.LD_Eliminar_plan_acción_traslado_balance_traslado_Ruta_Comunitaria(id);
        }
        public bool LD_Eliminar_plan_acción_traslado_profesionales_traslado_Ruta_Comunitaria(int id)
        {
            return L_D.LD_Eliminar_plan_acción_traslado_profesionales_traslado_Ruta_Comunitaria(id);
        }
        public bool LD_Insertar_plan_acción_traslado_balance_traslado_ruta_comunitaria(int id, int idPlan, int idComuidad, string actividad, string responsable, bool cumplida, string observaciones, int idUsuario)
        {
            return L_D.LD_Insertar_plan_acción_traslado_balance_traslado_ruta_comunitaria(id, idPlan, idComuidad, actividad, responsable, cumplida, observaciones, idUsuario);
        }
        public bool LD_Insertar_plan_acción_traslado_profesionales_traslado_ruta_comunitaria(int id, int idPlan, int idComuidad, string profesional, int idEntidad, string telefono, string correo, int idUsuario)
        {
            return L_D.LD_Insertar_plan_acción_traslado_profesionales_traslado_ruta_comunitaria(id, idPlan, idComuidad, profesional, idEntidad, telefono, correo, idUsuario);
        }

        public bool LD_Insertar_plan_acción_traslado_alistamiento_traslado_ruta_comunitaria(int id, int idPlan, int idComunidad, DateTime fechaRegistro, int idMunicipio, string direccion, int idDt, int idEntidad, string profesional, string correo, int idUsuario)
        {
            return L_D.LD_Insertar_plan_acción_traslado_alistamiento_traslado_ruta_comunitaria( id,  idPlan, idComunidad,  fechaRegistro,  idMunicipio,  direccion,  idDt,  idEntidad,  profesional,  correo, idUsuario);
        }

        public bool LD_Insertar_plan_acción_traslado_inventario_hogar_ruta_comunitaria(int id, int idPlan, int idComunidad, int idHogar, int estufas, int neveras, int utenciliosCocina, int camas, int colchones,int cobijas, int sofas, int sillas, int mesas, int equiposSonido, int juguetes, int bicicletas, int motos, int tulas, int peso, bool rotulacion, int idUsuario)
        {
            return L_D.LD_Insertar_plan_acción_traslado_inventario_hogar_ruta_comunitaria( id,  idPlan,  idComunidad,  idHogar,  estufas,  neveras,  utenciliosCocina,  camas,  colchones, cobijas,  sofas,  sillas,  mesas,  equiposSonido,  juguetes,  bicicletas,  motos,  tulas,  peso,  rotulacion, idUsuario);
        }

        public DataSet Get_Entidades_Plan_Accion_Traslado_Ruta_Comunitaria(int idPlan)
        {
            return L_D.LD_Consultar_plan_acción_traslado_Ruta_Comunitaria(idPlan);
        }
        public DataSet Get_Consultar_Categoria_plan_acción_traslado_Ruta_Comunitaria(int idPlan)
        {
            return L_D.LD_Consultar_Categoria_plan_acción_traslado_Ruta_Comunitaria(idPlan);
        }

        public DataSet Get_Consultar_Balance_traslado_derechos_Ruta_Comunitaria(int idPlan)
        {
            return L_D.LD_Consultar_Balance_traslado_derechos_Ruta_Comunitaria(idPlan);
        }
        public DataSet Get_Entidades_Plan_Accion_Traslado_categorias_Entidad(int idPlan, int idCategoria)
        {
            return L_D.LD_Consultar_plan_acción_traslado_categorias_Entidad_Ruta_Comunitaria(idPlan, idCategoria);
        }
        public DataSet Get_Entidades_Plan_Accion_Traslado_Entidad(int idPlan)
        {
            return L_D.LD_Consultar_plan_acción_traslado_Entidad_Ruta_Comunitaria(idPlan);
        }
        public DataSet Get_Tipo_Evidencia()
        {
            return L_D.LD_Consultar_Tipo_Evidencia();
        }
        public DataSet Get_plan_acción_traslado_balance_traslado_ruta_comunitaria(int idPlan)
        {
            return L_D.LD_plan_acción_traslado_balance_traslado_ruta_comunitaria(idPlan);
        }
        public DataSet Get_plan_acción_traslado_profesionales_traslado_ruta_comunitaria(int idPlan)
        {
            return L_D.LD_plan_acción_traslado_profesionales_traslado_ruta_comunitaria(idPlan);
        }
        public DataSet Get_plan_acción_traslado_Alistamiento_traslado_ruta_comunitaria(int idPlan)
        {
            return L_D.LD_plan_acción_traslado_Alistamiento_traslado_ruta_comunitaria(idPlan);
        }

        public DataSet Get_plan_acción_traslado_Inventario_hogar_ruta_comunitaria(int idComunidad)
        {
            return L_D.LD_plan_acción_traslado_Inventario_hogar_ruta_comunitaria(idComunidad);
        }

        public DataSet Get_plan_acción_traslado_Inventario_hogar_enseres_ruta_comunitaria(int idHogar)
        {
            return L_D.LD_plan_acción_traslado_Inventario_hogar_enseres_ruta_comunitaria(idHogar);
        }

        public DataSet Get_Persona_Plan_Accion_Traslado_por_numero_documento(string numDocumento)
        {
            return L_D.Get_Persona_Plan_Accion_Traslado_por_numero_documento(numDocumento);
        }
        public bool LD_Modificar_Persona_trasladar_plan_acción_traslado_ruta_comunitaria(int idPlan, int idComunidad, int idPersona, bool seTraslada, string motivo, int idUsuario)
        {
            return L_D.LD_Modificar_Persona_trasladar_plan_acción_traslado_ruta_comunitaria(idPlan, idComunidad, idPersona,  seTraslada, motivo, idUsuario);
        }
        public bool LD_Insertar_plan_acción_traslado_balance_evidencia_traslado_ruta_comunitaria(int id, string opcion,  int idRelacion, int idTipoEvidencia, string urlArchivo, string nombreArchivo, string extension,  int idUsuario, bool activo)
        {
            return L_D.LD_Insertar_plan_acción_traslado_balance_evidencia_traslado_ruta_comunitaria( id,opcion, idRelacion,  idTipoEvidencia,  urlArchivo, nombreArchivo,  extension,  idUsuario,  activo);
        }

        public DataSet Get_Personas_NO_se_trasladan_plan_acción_traslado_ruta_comunitaria(int idPlan)
        {
            return L_D.LD_Personas_NO_se_trasladan_plan_acción_traslado_ruta_comunitaria(idPlan);
        }
        public DataSet Get_Personas_SI_se_trasladan_plan_acción_traslado_ruta_comunitaria(int idComunidad)
        {
            return L_D.LD_Personas_SI_se_trasladan_plan_acción_traslado_ruta_comunitaria(idComunidad);
        }

        public DataSet Get_Plan_Accion_Traslado_balance_evidencia(int idRelacion, string opcion)
        {
            return L_D.Get_Plan_Accion_Traslado_balance_evidencia(idRelacion, opcion);
        }       
        public DataSet Get_Consultar_Balance_Metas_Ruta_Comunitaria(int idComunidad, string opcion)
        {
            return L_D.LD_Consultar_Balance_Metas_Ruta_Comunitaria(idComunidad, opcion);
        }
        #endregion

    }

}