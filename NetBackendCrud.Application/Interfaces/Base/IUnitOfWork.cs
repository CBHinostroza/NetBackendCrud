namespace NetBackendCrud.Application.Interfaces.Base
{
    public interface IUnitOfWork
    {
        #region InterfacesIO

        IPuestoRepository puestoRepository { get; }

        #endregion InterfacesIO

        #region Commits

        Task CompleteAsync();

        void Dispose();

        #endregion Commits
    }
}