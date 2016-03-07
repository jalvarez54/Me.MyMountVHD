namespace WindowsService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstallerMyMountVHDService = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerMyMountVHDService = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstallerMyMountVHDService
            // 
            this.serviceProcessInstallerMyMountVHDService.Password = null;
            this.serviceProcessInstallerMyMountVHDService.Username = null;
            // 
            // serviceInstallerMyMountVHDService
            // 
            this.serviceInstallerMyMountVHDService.ServiceName = "ServiceMyMountVHDService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerMyMountVHDService,
            this.serviceInstallerMyMountVHDService});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerMyMountVHDService;
        private System.ServiceProcess.ServiceInstaller serviceInstallerMyMountVHDService;
    }
}