namespace SchoolManagement.Services.DTO
{
    public class NotaDTO
    {
        public NotaDTO() { }

        public NotaDTO(long alunoId, AlunoDTO aluno, long disciplinaId, DisciplinaDTO disciplina, long turmaId, TurmaDTO turma, double? nota1, double? nota2, double? nota3, double? nota4, double? media, bool? aprovadoReprovado)
        {
            AlunoId = alunoId;
            Aluno = aluno;
            DisciplinaId = disciplinaId;
            Disciplina = disciplina;
            TurmaId = turmaId;
            Turma = turma;
            Nota1 = nota1;
            Nota2 = nota2;
            Nota3 = nota3;
            Nota4 = nota4;
            Media = media;
            AprovadoReprovado = aprovadoReprovado;
        }

        public long AlunoId { get; set; }
        public AlunoDTO Aluno { get; set; }
        public long DisciplinaId { get; set; }
        public DisciplinaDTO Disciplina { get; set; }
        public long TurmaId { get; set; }
        public TurmaDTO Turma { get; set; }

        public double? Nota1 { get; set; }
        public double? Nota2 { get; set; }
        public double? Nota3 { get; set; }
        public double? Nota4 { get; set; }
        public double? Media { get; set; }
        public bool? AprovadoReprovado { get; set; }
    }
}
