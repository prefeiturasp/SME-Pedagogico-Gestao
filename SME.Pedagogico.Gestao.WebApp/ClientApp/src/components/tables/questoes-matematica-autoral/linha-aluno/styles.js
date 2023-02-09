import { Input } from "antd";
import styled from "styled-components";
import { COLORS } from "../../colors";

export const RadioButton = styled(Input)`
  width: 16px;
  height: 16px;
  appearance: none;
  border-radius: 50%;
  border: 3px solid white;
  -webkit-appearance: none;
  box-shadow: 0 0 0 1px ${COLORS.RADIO.COLOR};

  &:focus {
    border-color: white;
    box-shadow: 0 0 0 1px ${COLORS.RADIO.COLOR};
    border-inline-end-width: initial;

    &:checked {
      box-shadow: 0 0 0 1px ${COLORS.RADIO.CHECKED_COLOR};
    }
  }

  &:hover {
    border-color: white;
    border-inline-end-width: initial;
    box-shadow: 0 0 0 1px ${COLORS.RADIO.COLOR};

    &:checked {
      box-shadow: 0 0 0 1px ${COLORS.RADIO.CHECKED_COLOR};
    }
  }

  &:checked {
    background: ${COLORS.RADIO.CHECKED_COLOR};
    box-shadow: 0 0 0 1px ${COLORS.RADIO.CHECKED_COLOR};
  }
`;
