using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using TecserSQL.Data.EDMX.TSSecurity;
using T0001_TRANSACTIONS = TecserSQL.Data.EDMX.TSSecurity.T0001_TRANSACTIONS;
using TSecRole = TecserSQL.Data.EDMX.TSSecurity.TSecRole;
using TSecRoleAssignment = TecserSQL.Data.EDMX.TSSecurity.TSecRoleAssignment;
using TSecUsr = TecserSQL.Data.EDMX.TSSecurity.TSecUsr;


namespace Tecser.Business.Security
{
    public class TsSecurityMng
    {
        //
        public static bool CheckUsernamePasswordOK(string user, string password)
        {
            if (password == null)
                return false;

            if (user == null)
                return false;

            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var data =
                    db.TSecUsr.SingleOrDefault(c => c.Username.ToUpper().Equals(user.ToString()) && c.Activo == true);
                if (data == null)
                    return false;

                if (password == data.Password)
                    return true;
                return false;
            }
        }
        public static bool CheckUserCanRunApplication(string username = null)
        {
            if (string.IsNullOrEmpty(username))
                username = GlobalApp.AppUsername;

            if (string.IsNullOrEmpty(username))
                return false;

            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var data = db.TSecUsr.SingleOrDefault(c => c.Activo && c.Username.ToUpper().Equals(username.ToString()));
                return data != null;
            }
        }

        /// <summary>
        /// Funcion usada para Enable/Disble los botones de un formulario 
        /// BtnXXX.Enabled= TsSecurityMng.CheckToEnableButton("role");
        /// </summary>

        public static bool CheckToEnableButton(string role)
        {
            if (role == null)
                return false;

            role = role.ToUpper();
            var username = GlobalApp.AppUsername.ToUpper();

            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var roleData = db.TSecRole.SingleOrDefault(c => c.RoleName.ToUpper().Equals(role));
                if (roleData == null)
                    return false;

                if (roleData.Activo == false)
                    return false;


                var roleAssignment =
                    db.TSecRoleAssignment.SingleOrDefault(
                        c => c.idRole.ToUpper().Equals(role) && c.idUser.ToUpper().Equals(username));

                if (roleAssignment == null)
                    return false;


                if (!roleAssignment.idActivo)
                    return false;
                return true;
            }
        }
        public static bool CheckifRoleIsGrantedToRun(string tcode, string role, bool logInTable = true, bool showMessageOnError = false)
        {
            if (string.IsNullOrEmpty(tcode))
            {
                tcode = @"FXRUN";
            }

            if (string.IsNullOrEmpty(role))
            {
                if (showMessageOnError)
                {
                    MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios para ejecutar esta transaccion",
                        @"Error en Permisos de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (logInTable)
                    SecurityLog.LogRoleToCheck(tcode, "?", false, "El Role ha chequear es vacio");
                return false;
            }

            tcode = tcode.ToUpper();
            role = role.ToUpper();
            var username = GlobalApp.AppUsername.ToUpper();

            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var roleData = db.TSecRole.SingleOrDefault(c => c.RoleName.ToUpper().Equals(role));
                if (roleData == null)
                {
                    if (showMessageOnError)
                    {
                        MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios para ejecutar esta transaccion",
                            @"Error en Permisos de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (logInTable)
                        SecurityLog.LogRoleToCheck(tcode, role, false, $"El Role {role}  no existe");
                    return false;
                }

                if (roleData.Activo == false)
                {
                    if (showMessageOnError)
                    {
                        MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios para ejecutar esta transaccion",
                            @"Error en Permisos de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (logInTable)
                        SecurityLog.LogRoleToCheck(tcode, role, false, $"El Role {role}  esta inactivo");
                    return false;
                }

                var roleAssignment =
                    db.TSecRoleAssignment.SingleOrDefault(
                        c => c.idRole.ToUpper().Equals(role) && c.idUser.ToUpper().Equals(username));

                if (roleAssignment == null)
                {
                    if (showMessageOnError)
                    {
                        MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios para ejecutar esta transaccion",
                            @"Error en Permisos de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (logInTable)
                        SecurityLog.LogRoleToCheck(tcode, role, false, "El Usuario no esta habilitado para ejecutar el role");
                    return false;
                }

                if (!roleAssignment.idActivo)
                {
                    if (showMessageOnError)
                    {
                        MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios para ejecutar esta transaccion",
                            @"Error en Permisos de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (logInTable)
                        SecurityLog.LogRoleToCheck(tcode, role, false, "La Relacion Usuario-Role esta Inactiva");
                    return false;
                }
                if (logInTable)
                    SecurityLog.LogRoleToCheck(tcode, role, true, "Usuario-Role Validado Correctamente");
                return true;
            }
        }

        //----------------------------------------------------------------------------------------
        //Nuevas funciones manejo interfaz security
        //----------------------------------------------------------------------------------------
        public List<TSecUsr> GetListUser(bool onlyActive = false)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                if (onlyActive)
                    return db.TSecUsr.Where(c => c.Activo == true).OrderBy(c => c.Username).ToList();

                return db.TSecUsr.OrderBy(c => c.Username).ToList();
            }
        }
        public List<TSecRole> GetListRole(bool onlyActive = false)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                if (onlyActive)
                    return db.TSecRole.Where(c => c.Activo == true).OrderBy(c => c.RoleName).ToList();

                return db.TSecRole.OrderBy(c => c.RoleName).ToList();
            }
        }
        public List<TSecRoleAssignment> GetListRoleAssignment(string username, string rolename, bool isActive)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                List<TSecRoleAssignment> data;
                if (username == null)
                {
                    if (rolename == null)
                    {
                        //sin usuario y sin role >> all
                        data = db.TSecRoleAssignment.OrderBy(c => c.idRole).ThenBy(c => c.idUser).ToList();
                    }
                    else
                    {
                        //all users y con role
                        data =
                            db.TSecRoleAssignment.Where(c => c.idRole == rolename)
                                .OrderBy(c => c.idRole)
                                .ThenBy(c => c.idUser)
                                .ToList();
                    }
                }
                else
                {
                    //con usuario
                    if (rolename == null)
                    {
                        data =
                            db.TSecRoleAssignment.Where(c => c.idUser == username)
                                .OrderBy(c => c.idRole)
                                .ThenBy(c => c.idUser)
                                .ToList();
                    }
                    else
                    {
                        //con usuario y con role
                        data =
                            db.TSecRoleAssignment.Where(c => c.idUser == username && c.idRole == rolename)
                                .OrderBy(c => c.idRole)
                                .ThenBy(c => c.idUser)
                                .ToList();
                    }
                }


                if (isActive)
                    return data.Where(c => c.idActivo).ToList();
                return data.ToList();
            }
        }
        public List<TSecRole> GetListRoleSinAsignacion(string username)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var data = new List<TSecRole>();
                if (username == null)
                    return data;

                data = db.TSecRole.Where(cx => cx.TSecRoleAssignment.All(c => c.idUser != username)).ToList();
                return data;
            }
        }
        public List<TSecUsr> GetListOfUsersWithoutARole(string role)
        {
            if (role == null)
                return null;

            var data = new List<TSecUsr>();
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                data = db.TSecUsr.Where(cx => cx.TSecRoleAssignment.All(c => c.idRole != role)).ToList();
                return data;
            }
        }
        public bool SetAccessRole(string username, string role)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var x =
                    db.TSecRoleAssignment.SingleOrDefault(
                        c => c.idUser.ToUpper().Equals(username.ToUpper()) && c.idRole.ToUpper().Equals(role.ToUpper()));
                if (x == null)
                {
                    //el role-user no existe lo crea
                    var data = new TSecRoleAssignment()
                    {
                        idRole = role,
                        idUser = username,
                        idActivo = true,
                    };
                    db.TSecRoleAssignment.Add(data);
                }
                else
                {
                    if (x.idActivo == false)
                    {
                        //el role-user existia pero inactivo-->lo activa
                        x.idActivo = true;
                    }
                    else
                    {
                        //El role-user ya existia activo
                        return false;
                    }
                }
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public bool UnSetAccessRole(string username, string role)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var x =
                    db.TSecRoleAssignment.SingleOrDefault(
                        c => c.idUser.ToUpper().Equals(username.ToUpper()) && c.idRole.ToUpper().Equals(role.ToUpper()));
                if (x == null)
                {
                    //el role-user no existia
                    return false;
                }
                else
                {
                    db.TSecRoleAssignment.Remove(x);
                }
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public T0001_TRANSACTIONS LoadTransactionData(string tcode)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var data = db.T0001_TRANSACTIONS.SingleOrDefault(c => c.TCode.ToUpper().Equals(tcode.ToUpper()));
                return data;
            }
        }
        public int GrabaRoleData(TSecRole roleData)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var data = db.TSecRole.SingleOrDefault(c => c.RoleName.ToUpper().Equals(roleData.RoleName.ToUpper()));
                if (data == null)
                {
                    db.TSecRole.Add(roleData);
                }
                else
                {
                    data.RoleDescription = roleData.RoleDescription;
                    data.Activo = roleData.Activo;
                }
                return db.SaveChanges();
            }
        }
        public int GrabaTcode(T0001_TRANSACTIONS tcodeData)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var data =
                    db.T0001_TRANSACTIONS.SingleOrDefault(c => c.TCode.ToUpper().Equals(tcodeData.TCode.ToUpper()));
                if (data == null)
                {
                    //El Tcode no existe crea tcode + role
                    var rolex = db.TSecRole.SingleOrDefault(c => c.RoleName == tcodeData.TCode);
                    if (rolex != null)
                    {
                        db.TSecRole.Remove(rolex);
                        db.SaveChanges();
                    }

                    db.T0001_TRANSACTIONS.Add(tcodeData);
                    var role = new TSecRole()
                    {
                        Activo = true,
                        IsTcode = true,
                        isFunction = false,
                        RoleName = tcodeData.TCode,
                        RoleDescription = "TX " + tcodeData.Description,
                        Modulo = tcodeData.Module,
                    };
                    db.TSecRole.Add(role);
                    if (db.SaveChanges() > 0)
                        return 1;
                    return 0;
                }
                else
                {
                    //Actualiza Tabla Transaccion
                    data.CheckPermission = tcodeData.CheckPermission;
                    data.Description = tcodeData.Description;
                    data.FormToCall = tcodeData.FormToCall;
                    data.Modo = tcodeData.Modo;
                    data.Module = tcodeData.Module;
                    data.Namespace = tcodeData.Namespace;
                    data.Visible = tcodeData.Visible;
                    data.Type = tcodeData.Type;
                    data.Arg1 = tcodeData.Arg1;
                    data.Arg2 = tcodeData.Arg2;
                    data.Arg3 = tcodeData.Arg3;
                    data.FunctionToCall = tcodeData.FunctionToCall;
                    data.NumberOfParameters = tcodeData.NumberOfParameters;
                    return db.SaveChanges() > 0 ? 1 : 0;
                }
            }
        }
        public bool TransaccionYaExiste(string tcodeName)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                var tx = db.T0001_TRANSACTIONS.SingleOrDefault(c => c.TCode.ToUpper().Equals(tcodeName.ToUpper()));
                if (tx == null)
                    return false;
                return true;
            }
        }
        public TSecRole GetRoleData(string roleName)
        {
            using (var db = new TecserDataS(GlobalApp.CnnSec))
            {
                return db.TSecRole.SingleOrDefault(c => c.RoleName.ToUpper().Equals(roleName.ToUpper()));
            }
        }

    }
}
