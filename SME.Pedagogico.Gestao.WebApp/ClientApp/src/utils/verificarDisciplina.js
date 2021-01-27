export const verificarDisciplina = (listDisciplines, disciplina) => {
    if(!listDisciplines || !listDisciplines.length) return;
    return listDisciplines.find(item => item.nome === disciplina);
};