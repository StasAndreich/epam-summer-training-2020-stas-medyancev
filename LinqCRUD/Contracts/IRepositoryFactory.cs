namespace LinqCRUD.Contracts
{
    /// <summary>
    /// Defines all repositories for models.
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Creates Subject Repository.
        /// </summary>
        /// <returns></returns>
        ISubjectRepository GetSubjectRepository();
        /// <summary>
        /// Creates Student Repository.
        /// </summary>
        /// <returns></returns>
        IStudentRepository GetStudentRepository();
        /// <summary>
        /// Creates Group Repository.
        /// </summary>
        /// <returns></returns>
        IGroupRepository GetGroupRepository();
        /// <summary>
        /// Creates Exam Repository.
        /// </summary>
        /// <returns></returns>
        IExamRepository GetExamRepository();
        /// <summary>
        /// Creates Assessment Repository.
        /// </summary>
        /// <returns></returns>
        IAssessmentRepository GetAssessmentRepository();
        /// <summary>
        /// Creates Assessment Repository.
        /// </summary>
        /// <returns></returns>
        IExaminerRepository GetExaminerRepository();
        /// <summary>
        /// Creates Assessment Repository.
        /// </summary>
        /// <returns></returns>
        ISpecialtyRepository GetSpecialtyRepository();
    }
}
