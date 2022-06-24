import React, { Component } from "react";
import "./Poll.css";
import Card from "../containers/Card";
import PollFilter from "./PollFilter";
import { DISCIPLINES_ENUM } from "../../Enums";

import { ClassRoomEnum } from "../polls/component/ClassRoomHelper";
import { connect } from "react-redux";
import { actionCreators as actionCreatorsPoll } from "../../store/Poll";
import { actionCreators as actionCreatorsPollOptionSelectLock } from "../../store/PollOptionSelectLock";
import { actionCreators as actionCreatorsData } from "../../store/Data";
import { actionCreators as actionCreatorsPollFilters } from "../../store/Filters";
import { actionCreators as actionCreatorAutoral } from "../../store/SondagemAutoral";

import { bindActionCreators } from "redux";

import TwoStepsSave from "../messaging/TwoStepsSave";
import MensagemConfirmacaoAutoral from "./SondagemPortuguesAutoral/mensagemConfirmacaoAutoral";
import Loader from "../loader/Loader";
import { verificarDisciplina } from "../../utils";

import { componentRenderPoll } from "./funcoes/componenteRenderPoll";
import { updatePollStudent } from "./funcoes/updatePollStudent";
import SelectChangeColor from "../inputs/SelectChangeColor";

class Poll extends Component {
  constructor(props) {
    super(props);
    this.state = {
      didAnswerPoll: false, //usar para perguntar para salvar sondagem
      sondagemType: ClassRoomEnum.ClassEmpty,
      showMessageBox: false, //para botao save
      showMessagePortugueseBox: false, //para botao para abrir portugues
      showMessageMathBox: false, //para botao para abrir matematica
      controleEdicaoBimestre: false,
      bimestreAtualControleEdicao: null,
      bimestres: [
        {
          value: "1",
          label: "1º Bimestre",
        },
        {
          value: "2",
          label: "2º Bimestre",
        },
        {
          value: "3",
          label: "3º Bimestre",
        },
        {
          value: "4",
          label: "4º Bimestre",
        },
      ],
    };
    this.componentRender = this.componentRender.bind(this);

    this.updatePollStudent = this.updatePollStudent.bind(this);
    this.savePollStudent = this.savePollStudent.bind(this);

    this.toggleButton = this.toggleButton.bind(this);

    this.openPortuguesePoll = this.openPortuguesePoll.bind(this);
    this.openMathPoll = this.openMathPoll.bind(this);

    this.checkButtonPortuguese = this.checkButtonPortuguese.bind(this);
    this.checkButtonMath = this.checkButtonMath.bind(this);
    this.checkButtonSave = this.checkButtonSave.bind(this);
    this.checkPollCard = this.checkPollCard.bind(this);

    this.props.pollMethods.set_poll_info(null, null, null);
    this.props.pollMethods.reset_poll_selected_filter_state();
    this.msnNaoExisteSondagem = "";
    // tempo para setar o valores default no state
    setTimeout(() => {}, 500);

    this.toggleMessageBox = this.toggleMessageBox.bind(this); //para salvar
    this.toggleMessagePortugueseBox =
      this.toggleMessagePortugueseBox.bind(this); //para botao portugues
    this.toggleMessageMathBox = this.toggleMessageMathBox.bind(this); //para botao matematica
    this.onChangeBimestre = this.onChangeBimestre.bind(this);
  }

  componentWillMount() {
    var todayDate = new Date();
    if (this.props.filter !== undefined) {
      var period = this.props.filter.period;
    }
  }

  toggleMessageBox() {
    this.setState({
      showMessageBox: !this.state.showMessageBox,
    });
  }

  toggleMessagePortugueseBox() {
    this.setState({
      showMessagePortugueseBox: !this.state.showMessagePortugueseBox,
    });
  }

  toggleMessageMathBox() {
    this.setState({
      showMessageMathBox: !this.state.showMessageMathBox,
    });
  }

  componentDidUpdate() {
    const portuguesTab = document.getElementById("portugues-tab");
    const matematicaTab = document.getElementById("matematica-tab");
    const btnSave = document.getElementById("btnSave");

    if (
      this.props.poll.navSelected === "portugues-tab" &&
      portuguesTab &&
      matematicaTab
    ) {
      portuguesTab.className =
        "btn btn-outline-primary btn-sm btn-planning active";
      matematicaTab.className = "btn btn-outline-primary btn-sm btn-planning";
    } else if (
      this.props.poll.navSelected === "matematica-tab" &&
      portuguesTab &&
      matematicaTab
    ) {
      portuguesTab.className = "btn btn-outline-primary btn-sm btn-planning";
      matematicaTab.className =
        "btn btn-outline-primary btn-sm btn-planning active";
    } else if (portuguesTab && matematicaTab) {
      portuguesTab.className = "btn btn-outline-primary btn-sm btn-planning";
      matematicaTab.className = "btn btn-outline-primary btn-sm btn-planning";
    }

    if (this.props.poll.newDataToSave) {
      if (btnSave) {
        document.getElementById("btnSave").className =
          "btn btn-save text-white";
      }
    } else {
      if (btnSave) {
        btnSave.className = "btn btn-save text-white deactive";
      }
    }
  }

  componentWillUpdate() {
    var todayDate = new Date();
    if (this.props.filters !== undefined) {
      if (this.props.filters.period && this.props.filters.period.length) {
        var period = this.props.filters.period;

        period.forEach((item) => {
          if (item.bimestre === 1) {
            if (
              todayDate >= new Date(item.dataInicio) &&
              todayDate <= new Date(item.dataFim)
            ) {
              if (this.props.pollOptionSelectLock.poll_1b_lock !== false)
                this.props.pollOptionSelectLockMethods.set_poll_1b_lock(false);
            } else {
              if (this.props.pollOptionSelectLock.poll_1b_lock !== true)
                this.props.pollOptionSelectLockMethods.set_poll_1b_lock(true);
            }
          }
          if (item.bimestre === 2) {
            if (
              todayDate >= new Date(item.dataInicio) &&
              todayDate <= new Date(item.dataFim)
            ) {
              if (this.props.pollOptionSelectLock.poll_2b_lock !== false) {
                this.props.pollOptionSelectLockMethods.set_poll_2b_lock(false);
                this.props.pollOptionSelectLockMethods.set_poll_1s_lock(false);
              }
            } else {
              if (this.props.pollOptionSelectLock.poll_2b_lock !== true) {
                this.props.pollOptionSelectLockMethods.set_poll_2b_lock(true);
                this.props.pollOptionSelectLockMethods.set_poll_1s_lock(true);
              }
            }
          }
          if (item.bimestre === 3) {
            if (
              todayDate >= new Date(item.dataInicio) &&
              todayDate <= new Date(item.dataFim)
            ) {
              if (this.props.pollOptionSelectLock.poll_3b_lock !== false) {
                this.props.pollOptionSelectLockMethods.set_poll_3b_lock(false);
              }
            } else {
              if (this.props.pollOptionSelectLock.poll_3b_lock !== true) {
                this.props.pollOptionSelectLockMethods.set_poll_3b_lock(true);
              }
            }
          }
          if (item.bimestre === 4) {
            if (
              todayDate >= new Date(item.dataInicio) &&
              todayDate <= new Date(item.dataFim)
            ) {
              if (this.props.pollOptionSelectLock.poll_4b_lock !== false) {
                this.props.pollOptionSelectLockMethods.set_poll_4b_lock(false);
                this.props.pollOptionSelectLockMethods.set_poll_2s_lock(false);
              }
            } else {
              if (this.props.pollOptionSelectLock.poll_4b_lock !== true) {
                this.props.pollOptionSelectLockMethods.set_poll_4b_lock(true);
                this.props.pollOptionSelectLockMethods.set_poll_2s_lock(true);
              }
            }
          }
        });
      }
    }
  }

  componentRender() {
    return componentRenderPoll(this.props, this.updatePollStudent);
  }

  updatePollStudent(sequence, subjectName, propertyName, value) {
    updatePollStudent(this.props, sequence, subjectName, propertyName, value);
  }

  async savePollStudent() {
    if (this.props.poll.onClickButtonSave) {
      const filtros = this.props.poll.selectedFilter;
      const itemSelecionado = this.props.autoral.perguntaSelecionada;

      const filtroSalvar = {
        anoLetivo: filtros.schoolYear,
        anoEscolar: filtros.yearClassroom,
        codigoDre: filtros.dreCodeEol,
        codigoUe: filtros.schoolCodeEol,
        codigoTurma: filtros.classroomCodeEol,
        componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
        perguntaId: itemSelecionado && itemSelecionado.id,
      };

      this.props.poll.onClickButtonSave(
        this.props.autoral.listaAlunosAutoralMatematica,
        this.props.autoral.listaPerguntas,
        this.props.autoral.listaPeriodos,
        filtroSalvar
      );
      return;
    }

    if (this.props.sondagemPortugues.salvar) {
      const sequenciasOrdens = this.props.sondagemPortugues.sequenciaOrdens;
      const idOrdemSelecionada = this.props.sondagemPortugues.ordemSelecionada;
      const periodoSelecionadoSalvar =
        this.props.sondagemPortugues.periodoSelecionado;
      const grupo = this.props.sondagemPortugues.grupoSelecionado;
      const idOrdem = this.props.sondagemPortugues.ordemSelecionada;

      let alunosMutaveis = Object.assign(
        [],
        this.props.sondagemPortugues.alunos
      );
      let filtrosMutaveis = Object.assign(
        {},
        this.props.sondagemPortugues.filtros
      );

      const sequenciaOrdemSelecionada = sequenciasOrdens
        ? sequenciasOrdens.findIndex(
            (sequencia) => sequencia.ordemId === idOrdemSelecionada
          )
        : 0;

      try {
        this.props.sondagemPortugues.salvar({
          perguntasSalvar: this.props.sondagemPortugues.perguntas,
          alunosMutaveis,
          filtrosMutaveis,
          periodoSelecionadoSalvar,
          grupo,
          idOrdem,
          sequenciaOrdemSelecionada,
        });
      } catch (e) {
        this.props.pollMethods.setLoadingSalvar(false);
      }
      return;
    }

    if (
      this.props.pollStudents &&
      this.props.pollStudents.pollSelected === ClassRoomEnum.ClassMTAutoral
    ) {
      this.props.autoralMethods.salvaSondagemAutoralMatematica(
        this.props.autoral.listaAlunosAutoralMatematica
      );
    } else if (
      this.props.pollStudents &&
      this.props.pollStudents.pollSelected === ClassRoomEnum.ClassPTAutoral
    ) {
    } else if (this.props.poll.pollSelected !== null) {
      if (this.props.poll.pollSelected === ClassRoomEnum.ClassPT) {
        this.props.pollMethods.save_poll_portuguese_student(
          this.props.poll.students
        );
      } else if (this.props.poll.pollSelected === ClassRoomEnum.ClassMT) {
        if (this.props.poll.pollTypeSelected === "Numeric") {
          this.props.pollMethods.save_poll_math_numbers_students(
            this.props.poll.studentsPollMathNumbers
          );
        } else if (this.props.poll.pollTypeSelected === "CA") {
          this.props.pollMethods.save_poll_math_ca_students(
            this.props.poll.studentsPollMathCA
          );
        } else if (this.props.poll.pollTypeSelected === "CM") {
          this.props.pollMethods.save_poll_math_cm_students(
            this.props.poll.studentsPollMathCM
          );
        }
      }
      this.props.dataMethods.reset_new_data_state();
    }
  }

  toggleButton(elementSeleted) {
    this.props.pollMethods.setNavegacaoSelecionada(elementSeleted);
    this.props.pollMethods.setBimestre("");
  }

  openPortuguesePoll() {
    this.props.dataMethods.reset_new_data_state();
    this.toggleButton("portugues-tab");
    var classRoomMock = this.props.poll.selectedFilter;
    this.props.pollMethods.set_poll_list_initial_state();

    if (classRoomMock.yearClassroom < 4) {
      this.props.pollMethods.set_poll_info(
        ClassRoomEnum.ClassPT,
        "",
        classRoomMock.yearClassroom
      ); //passar pollSelected, pollTypeSelected, pollYear
    } else {
      this.props.pollMethods.set_poll_info(
        ClassRoomEnum.ClassPTAutoral,
        "",
        classRoomMock.yearClassroom
      );
    }

    this.props.pollMethods.get_poll_portuguese_students(classRoomMock);
  }

  PreencherSpanInfro() {
    var info = document.getElementById("span-matematica-tab");
    if (info != null) {
      info.innerHTML = "Sondagem não disponível neste ano letivo.";
    }
  }
  openMathPoll() {
    this.props.dataMethods.reset_new_data_state();
    this.toggleButton("matematica-tab");
    var classRoomMock = this.props.poll.selectedFilter;
    this.msnNaoExisteSondagem = "";
    var naoExibeBotao =
      parseInt(this.props.poll.selectedFilter.schoolYear) === 2019 &&
      parseInt(this.props.poll.selectedFilter.yearClassroom) >= 7 &&
      parseInt(this.props.poll.selectedFilter.yearClassroom) <= 9;
    if (naoExibeBotao) {
      this.PreencherSpanInfro();
    } else {
      this.props.pollMethods.set_poll_list_initial_state();
      if (classRoomMock.yearClassroom > 6) {
        this.props.pollMethods.set_poll_info(
          ClassRoomEnum.ClassMTAutoral,
          "",
          classRoomMock.yearClassroom
        );
      } else if (
        classRoomMock.yearClassroom === "1" ||
        classRoomMock.yearClassroom === "2" ||
        classRoomMock.yearClassroom === "3"
      ) {
        this.props.pollMethods.set_poll_info(
          ClassRoomEnum.ClassMT,
          "Numeric",
          classRoomMock.yearClassroom
        );
      } else {
        this.props.pollMethods.set_poll_info(
          ClassRoomEnum.ClassMT,
          "CA",
          classRoomMock.yearClassroom
        );
      }

      if (classRoomMock.schoolYear >= 2022) return;

      if (this.props.poll.pollTypeSelected === "Numeric") {
        this.props.pollMethods.get_poll_math_numbers_students(classRoomMock);
      } else if (this.props.poll.pollTypeSelected === "CA") {
        this.props.pollMethods.get_poll_math_ca_students(classRoomMock);
      } else if (this.props.poll.pollTypeSelected === "CM") {
        this.props.pollMethods.get_poll_math_cm_students(classRoomMock);
      }
    }
  }

  checkButtonPortuguese() {
    var btn;
    const { listDisciplines } = this.props.filters;
    const existDisciplina = verificarDisciplina(
      listDisciplines,
      DISCIPLINES_ENUM.DISCIPLINA_PORTUGUES.Descricao
    );
    if (!existDisciplina) return;

    if (
      this.props.poll.selectedFilter.yearClassroom !== null &&
      this.props.poll.selectedFilter.yearClassroom !== undefined
    ) {
      if (this.props.data.newDataToSave) {
        btn = (
          <li className="nav-item">
            <button
              className="btn btn-outline-primary btn-sm btn-planning"
              onClick={this.toggleMessagePortugueseBox}
            >
              Língua portuguesa
            </button>
          </li>
        );
      } else {
        btn = (
          <li className="nav-item">
            <button
              className="btn btn-outline-primary btn-sm btn-planning"
              id="portugues-tab"
              onClick={this.openPortuguesePoll}
            >
              Língua Portuguesa
            </button>
          </li>
        );
      }
    } else if (
      this.props.poll.selectedFilter.yearClassroom !== null &&
      parseInt(this.props.poll.selectedFilter.yearClassroom) >= 4 &&
      this.props.poll.selectedFilter.yearClassroom !== undefined
    ) {
      if (this.props.data.newDataToSave) {
        btn = (
          <li className="nav-item">
            <button
              className="btn btn-outline-primary btn-sm btn-planning"
              onClick={this.toggleMessagePortugueseBox}
            ></button>
          </li>
        );
      } else {
        btn = (
          <li className="nav-item">
            <button
              className="btn btn-outline-primary btn-sm btn-planning"
              id="portugues-tab"
              onClick={this.openPortuguesePoll}
            >
              Língua Portuguesa
            </button>
          </li>
        );
      }
    }
    return btn;
  }

  checkButtonMath() {
    var btn;
    const { listDisciplines } = this.props.filters;
    const existDisciplina = verificarDisciplina(
      listDisciplines,
      DISCIPLINES_ENUM.DISCIPLINA_MATEMATICA.Descricao
    );
    if (!existDisciplina) return;

    if (
      this.props.poll.selectedFilter.yearClassroom !== null &&
      this.props.poll.selectedFilter.yearClassroom !== undefined
    ) {
      if (this.props.data.newDataToSave) {
        btn = (
          <li className="nav-item">
            <button
              className="btn btn-outline-primary btn-sm btn-planning"
              onClick={this.toggleMessageMathBox}
            >
              Matem&aacute;tica
            </button>
          </li>
        );
      } else {
        btn = (
          <li className="nav-item">
            <button
              className="btn btn-outline-primary btn-sm btn-planning"
              id="matematica-tab"
              onClick={this.openMathPoll}
            >
              Matem&aacute;tica
            </button>
            <span
              className="sc-text-orange sc-text-size-3"
              id="span-matematica-tab"
            >
              {this.msnNaoExisteSondagem}
            </span>
          </li>
        );
      }
    }
    return btn;
  }

  checkButtonSave() {
    var btn;
    if (
      this.props.poll.selectedFilter.yearClassroom !== null &&
      this.props.poll.selectedFilter.yearClassroom !== undefined
    ) {
      btn = (
        <li className="nav-item">
          <div className="form-inline">
            <button
              id="btnSave"
              className="btn btn-save text-white deactive"
              onClick={this.toggleMessageBox}
              disabled={!this.props.poll.newDataToSave}
            >
              Salvar
            </button>
            <TwoStepsSave
              show={this.state.showMessageBox}
              showControl={this.toggleMessageBox}
              runMethod={this.savePollStudent}
            />
          </div>
        </li>
      );
    }
    return btn;
  }

  checkPollCard() {
    if (
      this.props.poll.selectedFilter.yearClassroom !== null &&
      this.props.poll.selectedFilter.classroomCodeEol !== "" &&
      this.props.poll.selectedFilter.yearClassroom !== undefined
    ) {
      return "false";
    } else {
      return "true";
    }
  }

  onChangeBimestre(e) {
    const bimestre = e.target.value;
    if (this.props.data.newDataToSave) {
      this.toggleMessageMathBox();
      this.setState({
        controleEdicaoBimestre: true,
        bimestreAtualControleEdicao: bimestre,
      });

      return;
    }
    this.props.pollMethods.setBimestre(bimestre);
  }

  atualizarBimestre() {
    this.setState({
      controleEdicaoBimestre: false,
      bimestreAtualControleEdicao: null,
    });
    this.props.pollMethods.setBimestre(this.state.bimestreAtualControleEdicao);
  }

  render() {
    return (
      <>
        <MensagemConfirmacaoAutoral
          controleExibicao={this.toggleMessagePortugueseBox}
          acaoPrincipal={this.savePollStudent}
          acaoSecundaria={async () => {
            this.openPortuguesePoll();
          }}
          exibir={this.state.showMessagePortugueseBox}
          acaoFeedBack={async () => {
            this.openPortuguesePoll();
          }}
        />
        <MensagemConfirmacaoAutoral
          controleExibicao={this.toggleMessageMathBox}
          acaoPrincipal={this.savePollStudent}
          acaoSecundaria={async () => {
            if (!this.state.controleEdicaoBimestre) {
              this.openMathPoll();
              return;
            }
            this.atualizarBimestre();
          }}
          exibir={this.state.showMessageMathBox}
          acaoFeedBack={async () => {
            if (!this.state.controleEdicaoBimestre) {
              this.openMathPoll();
              return;
            }
            this.atualizarBimestre();
          }}
        />
        <Card className="mb-3 mt-5">
          <PollFilter reports={false} savePollStudent={this.savePollStudent} />
        </Card>
        <Card id="classRecord-poll" hide={this.checkPollCard()}>
          <nav className="container-tabpanel navbar">
            <ul className="nav" role="tablist">
              {this.checkButtonPortuguese()}
              {this.checkButtonMath()}
            </ul>
            <ul className="nav navbar-nav ml-auto">{this.checkButtonSave()}</ul>
          </nav>
          {this.props.poll.navSelected === "matematica-tab" &&
            this.props.poll.selectedFilter.schoolYear >= 2022 && (
              <div className="col-md-2 pb-2">
                <SelectChangeColor
                  id ="comboSemestre"
                  className="custom-select-sm"
                  defaultText="Bimestre"
                  options={this.state.bimestres}
                  onChange={this.onChangeBimestre}
                  value={this.props.poll.bimestre}
                />
              </div>
            )}
          <Loader loading={this.props.poll.loadingSalvar}>
            {this.componentRender()}
          </Loader>
        </Card>
      </>
    );
  }
}

export default connect(
  (state) => ({
    poll: state.poll,
    pollOptionSelectLock: state.pollOptionSelectLock,
    data: state.data,
    filters: state.filters,
    autoral: state.autoral,
    sondagemPortugues: state.sondagemPortugues,
    user: state.user,
  }),
  (dispatch) => ({
    pollMethods: bindActionCreators(actionCreatorsPoll, dispatch),
    pollOptionSelectLockMethods: bindActionCreators(
      actionCreatorsPollOptionSelectLock,
      dispatch
    ),
    dataMethods: bindActionCreators(actionCreatorsData, dispatch),
    filterMethods: bindActionCreators(actionCreatorsPollFilters, dispatch),
    autoralMethods: bindActionCreators(actionCreatorAutoral, dispatch),
  })
)(Poll);
