import { ClassRoomEnum } from "../../polls/component/ClassRoomHelper";

export const updatePollStudent = ( props, sequence, subjectName, propertyName, value) => {
  if (props.poll.pollSelected === ClassRoomEnum.ClassPT) {
    const pollStudents = props.poll.students;
    for (let i = 0; i < pollStudents.length; i++) {
      if (pollStudents[i].studentCodeEol === sequence) {
        if (subjectName === "portuguese") {
          switch (propertyName) {
            case "t1e":
              pollStudents[i].t1e = value;
              break;
            case "t1l":
              pollStudents[i].t1l = value;
              break;
            case "t2e":
              pollStudents[i].t2e = value;
              break;
            case "t2l":
              pollStudents[i].t2l = value;
              break;
            case "t3e":
              pollStudents[i].t3e = value;
              break;
            case "t3l":
              pollStudents[i].t3l = value;
              break;
            case "t4e":
              pollStudents[i].t4e = value;
              break;
            case "t4l":
              pollStudents[i].t4l = value;
              break;
            default:
              break;
          }
          break;
        }
      }
    }
    props.pollMethods.update_poll_students(pollStudents);
  } else if (props.poll.pollSelected === ClassRoomEnum.ClassMT) {
    if (props.poll.pollTypeSelected === "Numeric") {
      const pollStudents = props.poll.studentsPollMathNumbers;
      for (let i = 0; i < pollStudents.length; i++) {
        if (pollStudents[i].studentCodeEol === sequence) {
          if (subjectName === "mathalfabetizacao") {
            switch (propertyName) {
              case "familiares1S":
                pollStudents[i].familiares1S = value;
                break;
              case "familiares2S":
                pollStudents[i].familiares2S = value;
                break;
              case "opacos1S":
                pollStudents[i].opacos1S = value;
                break;
              case "opacos2S":
                pollStudents[i].opacos2S = value;
                break;
              case "transparentes1S":
                pollStudents[i].transparentes1S = value;
                break;
              case "transparentes2S":
                pollStudents[i].transparentes2S = value;
                break;
              case "terminamzero1S":
                pollStudents[i].terminamzero1S = value;
                break;
              case "terminamzero2S":
                pollStudents[i].terminamzero2S = value;
                break;
              case "algarismos1S":
                pollStudents[i].algarismos1S = value;
                break;
              case "algarismos2S":
                pollStudents[i].algarismos2S = value;
                break;
              case "processo1S":
                pollStudents[i].processo1S = value;
                break;
              case "processo2S":
                pollStudents[i].processo2S = value;
                break;
              case "zerointercalados1S":
                pollStudents[i].zerointercalados1S = value;
                break;
              case "zerointercalados2S":
                pollStudents[i].zerointercalados2S = value;
                break;
              default:
                break;
            }
            break;
          }
        }
      }
      props.pollMethods.update_poll_math_numbers_students(pollStudents);
    } else if (props.poll.pollTypeSelected === "CA") {
      const pollStudents = props.poll.studentsPollMathCA;
      for (let i = 0; i < pollStudents.length; i++) {
        if (pollStudents[i].studentCodeEol === sequence) {
          if (subjectName === "math") {
            switch (propertyName) {
              case "orderm1Ideia1S":
                pollStudents[i].orderm1Ideia1S = value;
                break;
              case "orderm1Resultado1S":
                pollStudents[i].orderm1Resultado1S = value;
                break;
              case "orderm1Ideia2S":
                pollStudents[i].orderm1Ideia2S = value;
                break;
              case "orderm1Resultado2S":
                pollStudents[i].orderm1Resultado2S = value;
                break;

              case "orderm2Ideia1S":
                pollStudents[i].orderm2Ideia1S = value;
                break;
              case "orderm2Resultado1S":
                pollStudents[i].orderm2Resultado1S = value;
                break;
              case "orderm2Ideia2S":
                pollStudents[i].orderm2Ideia2S = value;
                break;
              case "orderm2Resultado2S":
                pollStudents[i].orderm2Resultado2S = value;
                break;

              case "orderm3Ideia1S":
                pollStudents[i].orderm3Ideia1S = value;
                break;
              case "orderm3Resultado1S":
                pollStudents[i].orderm3Resultado1S = value;
                break;
              case "orderm3Ideia2S":
                pollStudents[i].orderm3Ideia2S = value;
                break;
              case "orderm3Resultado2S":
                pollStudents[i].orderm3Resultado2S = value;
                break;

              case "orderm4Ideia1S":
                pollStudents[i].orderm4Ideia1S = value;
                break;
              case "orderm4Resultado1S":
                pollStudents[i].orderm4Resultado1S = value;
                break;
              case "orderm4Ideia2S":
                pollStudents[i].orderm4Ideia2S = value;
                break;
              case "orderm4Resultado2S":
                pollStudents[i].orderm4Resultado2S = value;
                break;

              case "orderm5Ideia1S":
                pollStudents[i].orderm5Ideia1S = value;
                break;
              case "orderm5Resultado1S":
                pollStudents[i].orderm5Resultado1S = value;
                break;
              case "orderm5Ideia2S":
                pollStudents[i].orderm5Ideia2S = value;
                break;
              case "orderm5Resultado2S":
                pollStudents[i].orderm5Resultado2S = value;
                break;

              case "orderm6Ideia1S":
                pollStudents[i].orderm6Ideia1S = value;
                break;
              case "orderm6Resultado1S":
                pollStudents[i].orderm6Resultado1S = value;
                break;
              case "orderm6Ideia2S":
                pollStudents[i].orderm6Ideia2S = value;
                break;
              case "orderm6Resultado2S":
                pollStudents[i].orderm6Resultado2S = value;
                break;

              case "orderm7Ideia1S":
                pollStudents[i].orderm7Ideia1S = value;
                break;
              case "orderm7Resultado1S":
                pollStudents[i].orderm7Resultado1S = value;
                break;
              case "orderm7Ideia2S":
                pollStudents[i].orderm7Ideia2S = value;
                break;
              case "orderm7Resultado2S":
                pollStudents[i].orderm7Resultado2S = value;
                break;

              case "orderm8Ideia1S":
                pollStudents[i].orderm8Ideia1S = value;
                break;
              case "orderm8Resultado1S":
                pollStudents[i].orderm8Resultado1S = value;
                break;
              case "orderm8Ideia2S":
                pollStudents[i].orderm8Ideia2S = value;
                break;
              case "orderm8Resultado2S":
                pollStudents[i].orderm8Resultado2S = value;
                break;
              default:
                break;
            }
            break;
          }
        }
      }
      props.pollMethods.update_poll_math_ca_students(pollStudents);
    } else if (props.poll.pollTypeSelected === "CM") {
      const pollStudents = props.poll.studentsPollMathCM;
      for (let i = 0; i < pollStudents.length; i++) {
        if (pollStudents[i].studentCodeEol === sequence) {
          if (subjectName === "math") {
            switch (propertyName) {
              case "orderm1Ideia1S":
                pollStudents[i].orderm1Ideia1S = value;
                break;
              case "orderm1Resultado1S":
                pollStudents[i].orderm1Resultado1S = value;
                break;
              case "orderm1Ideia2S":
                pollStudents[i].orderm1Ideia2S = value;
                break;
              case "orderm1Resultado2S":
                pollStudents[i].orderm1Resultado2S = value;
                break;

              case "orderm2Ideia1S":
                pollStudents[i].orderm2Ideia1S = value;
                break;
              case "orderm2Resultado1S":
                pollStudents[i].orderm2Resultado1S = value;
                break;
              case "orderm2Ideia2S":
                pollStudents[i].orderm2Ideia2S = value;
                break;
              case "orderm2Resultado2S":
                pollStudents[i].orderm2Resultado2S = value;
                break;

              case "orderm3Ideia1S":
                pollStudents[i].orderm3Ideia1S = value;
                break;
              case "orderm3Resultado1S":
                pollStudents[i].orderm3Resultado1S = value;
                break;
              case "orderm3Ideia2S":
                pollStudents[i].orderm3Ideia2S = value;
                break;
              case "orderm3Resultado2S":
                pollStudents[i].orderm3Resultado2S = value;
                break;

              case "orderm4Ideia1S":
                pollStudents[i].orderm4Ideia1S = value;
                break;
              case "orderm4Resultado1S":
                pollStudents[i].orderm4Resultado1S = value;
                break;
              case "orderm4Ideia2S":
                pollStudents[i].orderm4Ideia2S = value;
                break;
              case "orderm4Resultado2S":
                pollStudents[i].orderm4Resultado2S = value;
                break;

              case "orderm5Ideia1S":
                pollStudents[i].orderm5Ideia1S = value;
                break;
              case "orderm5Resultado1S":
                pollStudents[i].orderm5Resultado1S = value;
                break;
              case "orderm5Ideia2S":
                pollStudents[i].orderm5Ideia2S = value;
                break;
              case "orderm5Resultado2S":
                pollStudents[i].orderm5Resultado2S = value;
                break;

              case "orderm6Ideia1S":
                pollStudents[i].orderm6Ideia1S = value;
                break;
              case "orderm6Resultado1S":
                pollStudents[i].orderm6Resultado1S = value;
                break;
              case "orderm6Ideia2S":
                pollStudents[i].orderm6Ideia2S = value;
                break;
              case "orderm6Resultado2S":
                pollStudents[i].orderm6Resultado2S = value;
                break;

              case "orderm7Ideia1S":
                pollStudents[i].orderm7Ideia1S = value;
                break;
              case "orderm7Resultado1S":
                pollStudents[i].orderm7Resultado1S = value;
                break;
              case "orderm7Ideia2S":
                pollStudents[i].orderm7Ideia2S = value;
                break;
              case "orderm7Resultado2S":
                pollStudents[i].orderm7Resultado2S = value;
                break;

              case "orderm8Ideia1S":
                pollStudents[i].orderm8Ideia1S = value;
                break;
              case "orderm8Resultado1S":
                pollStudents[i].orderm8Resultado1S = value;
                break;
              case "orderm8Ideia2S":
                pollStudents[i].orderm8Ideia2S = value;
                break;
              case "orderm8Resultado2S":
                pollStudents[i].orderm8Resultado2S = value;
                break;
              default:
                break;
            }
            break;
          }
        }
      }
      props.pollMethods.update_poll_math_cm_students(pollStudents);
    }
  }
  props.dataMethods.set_new_data_state();
};
