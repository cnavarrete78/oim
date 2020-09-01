function textonly(myfield, e, dec)
{
    var key;
    var keychar;

    if (window.event)
        key = window.event.keyCode;
    else if (e)
        key = e.which;
    else
        return true;
    
    keychar = String.fromCharCode(key);
    
    // Tildes
    if ((("ÁÉÍÓÚÝáéíóúý'`´").indexOf(keychar) > -1))  
        return false;    
    else
        return true;

}

function numbersonly(myfield, e, dec)
{
    var key;
    var keychar;

    if (window.event)
        key = window.event.keyCode;
    else if (e)
        key = e.which;
    else
        return true;
    
    keychar = String.fromCharCode(key);

    if ((key==null) || (key==0) || (key==8) || (key==9) || (key==27))   // control keys
        return true;
    else if ((("0123456789").indexOf(keychar) > -1))                    // numbers
        return true;
    else
        return false;
}

/* Control Calendario */
function Calendar_Function(TextId, BtnId) {
    Calendar.setup({
        trigger: BtnId,
        inputField: TextId,
        dateFormat: "%d %b %Y",
        animation: false,
        onSelect: function() {
            this.hide();            
        },
        disabled: function(date) {
            if (date.getDay() == 6) {
                return true;
            } else if (date.getDay() == 0) {
                return true;
            } else {
                return false;
            }            
        }
    });
}

function Calendar_Function_Consulta(TextId, BtnId) {
    Calendar.setup({
        trigger: BtnId,
        inputField: TextId,
        dateFormat: "%d/%m/%Y",
        animation: false,
        onSelect: function() {
            this.hide();
        },
        disabled: function(date) {
            if (date.getDay() == 6) {
                return true;
            } else if (date.getDay() == 0) {
                return true;
            } else {
                return false;
            }
        }
    });
}

function Calendar_Function_Time(TextId, BtnId) {
    Calendar.setup({
        trigger: BtnId,
        inputField: TextId,
        dateFormat: "%d %b %Y  %H:%M",
        animation: false,
        showTime: true,
        onSelect: function() {
            this.hide();
        }
    });
}

function Calendar_FunctionPostback(sender, e, TextId, BtnId) {

    miFecha = new Date();

    Calendar.setup({
        trigger: BtnId,
        inputField: TextId,
        dateFormat: "%d %b %Y",
        animation: false,
        max: miFecha,
        onSelect: function() {
            this.hide();
            __doPostBack(sender, e);
        }
    });
}

function Calendar_FunctionReporte(TextId, BtnId) {

    miFecha = new Date();

    Calendar.setup({
        trigger: BtnId,
        inputField: TextId,
        dateFormat: "%d %b %Y",
        animation: false,
        max: miFecha,
        onSelect: function() {
            this.hide();
        }
    });
}

/* Fin Control Calendario */

/* Control Upload */
function uploadSuccess() {
    document.getElementById("uploadMessage").style.display = "none";
}

function uploadError(sender, args) {
    showUploadMessage("An error occurred during uploading. " + args.get_errorMessage(), '#ff0000');
}
function showUploadMessage(text, color) {
    var mensaje;
    mensaje = document.getElementById("uploadMessage");
    mensaje.style.display = "inline";
}
/* Fin Control Upload */

/* Validacion Fechas */
function ValidaFecha(sender, args) {
    var str = args.Value;
    str = str.replace("Ene", "Jan");
    str = str.replace("Feb", "Feb");
    str = str.replace("Mar", "Mar");
    str = str.replace("Abr", "Apr");
    str = str.replace("May", "May");
    str = str.replace("Jun", "Jun");
    str = str.replace("Jul", "Jul");
    str = str.replace("Ago", "Aug");
    str = str.replace("Sep", "Sep");
    str = str.replace("Oct", "Oct");
    str = str.replace("Nov", "Nov");
    str = str.replace("Dic", "Dec");

    var today = new Date();
    var myDate = new Date(str);

    // si la fecha es de otro año -> valida
    if (myDate.getFullYear() < today.getFullYear()) {
        args.IsValid = false;
        return;
    }

    // si la fecha es mayor a la actual -> valida
    if (myDate > today) {
        args.IsValid = false;
        return;
    }

    // si le fecha esta fuera del trimestre actual -> valida
    switch (myDate.getMonth()) {
        case 0:
        case 1:
        case 2:
            if (today.getMonth() > 2)
                args.IsValid = false;
            return;

        case 3:
        case 4:
        case 5:
            if (today.getMonth() < 3 || Fecha.getMonth() > 5)
                args.IsValid = false;
            return;

        case 6:
        case 7:
        case 8:
            if (today.getMonth() < 6 || Fecha.getMonth() > 9)
                args.IsValid = false;
            return;

        case 9:
        case 10:
        case 11:
            if (today.getMonth() < 9)
                args.IsValid = false;
            return;
    }

    args.IsValid = true;
}
/* Fin Validacion Fechas */
