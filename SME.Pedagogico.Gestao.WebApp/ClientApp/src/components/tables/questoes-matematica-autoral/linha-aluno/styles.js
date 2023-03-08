import { Input } from "antd";
import styled from "styled-components";
import { COLORS } from "../../colors";

export const Label = styled.label`
  width: 100%;
  height: 100%;
  display: flex;
  margin-bottom: 0;
  align-items: center;
  justify-content: center;
`;

export const RadioButton = styled(Input)`
  width: 16px;
  height: 16px;
  appearance: none;
  border-radius: 50%;
  border: 3px solid white;
  -webkit-appearance: none;
  box-shadow: 0 0 1px 1px ${COLORS.RADIO.COLOR};

  &.light-border {
    box-shadow: 0 0 1px 1px ${COLORS.RADIO.LIGHT_COLOR} !important;
  }

  &:focus {
    border-color: white;
    border-inline-end-width: medium;
    box-shadow: 0 0 1px 1px ${COLORS.RADIO.COLOR} !important;

    &:checked {
      box-shadow: 0 0 1px 1px ${COLORS.RADIO.CHECKED_COLOR} !important;
    }
  }

  &:hover {
    border-color: white;
    border-inline-end-width: medium;
    box-shadow: 0 0 1px 1px ${COLORS.RADIO.COLOR};

    &:checked {
      box-shadow: 0 0 1px 1px ${COLORS.RADIO.CHECKED_COLOR};
    }
  }

  &:checked {
    background: ${COLORS.RADIO.CHECKED_COLOR};
    box-shadow: 0 0 1px 1px ${COLORS.RADIO.CHECKED_COLOR};
  }
`;
