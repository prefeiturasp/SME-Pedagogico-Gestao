import StudentPollMath1ACard from "../../polls/StudentPollMath1ACard";
import StudentPollMath2ACard from "../../polls/StudentPollMath2ACard";
import StudentPollMath2ACMCard from "../../polls/StudentPollMath2ACMCard";
import StudentPollMath3ACACard from "../../polls/StudentPollMath3ACACard";
import StudentPollMath3ACMCard from "../../polls/StudentPollMath3ACMCard";
import StudentPollMath4ACACard from "../../polls/StudentPollMath4ACACard";
import StudentPollMath4ACMCard from "../../polls/StudentPollMath4ACMCard";
import StudentPollMath5ACACard from "../../polls/StudentPollMath5ACACard";
import StudentPollMath5ACMCard from "../../polls/StudentPollMath5ACMCard";
import StudentPollMath6ACACard from "../../polls/StudentPollMath6ACACard";
import StudentPollMath6ACMCard from "../../polls/StudentPollMath6ACMCard";

export const componenteMatematica = {
  1: {
    CA: StudentPollMath1ACard,
  },
  2: {
    CA: StudentPollMath2ACard,
    CM: StudentPollMath2ACMCard,
  },
  3: {
    CA: StudentPollMath3ACACard,
    CM: StudentPollMath3ACMCard,
  },
  4: {
    CA: StudentPollMath4ACACard,
    CM: StudentPollMath4ACMCard,
  },
  5: {
    CA: StudentPollMath5ACACard,
    CM: StudentPollMath5ACMCard,
  },
  6: {
    CA: StudentPollMath6ACACard,
    CM: StudentPollMath6ACMCard,
  },
};

export const escolherPropriedade = {
  CA: "studentsPollMathCA",
  CM: "studentsPollMathCM",
};
