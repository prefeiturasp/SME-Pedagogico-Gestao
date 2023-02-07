import { Input } from "antd";
import styled from "styled-components";
import { COLORS } from "../../colors";

export const RadioButton = styled(Input)`
  width: 16px;
  height: 16px;
  accent-color: ${COLORS.RADIO.COLOR};
  border-color: ${COLORS.RADIO.BORDER};

  &:focus {
    box-shadow: none;
  }
`;
