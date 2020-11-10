import React from "react";
import PropTypes from "prop-types";
import {
  LoaderWrapper,
  DivLoading,
  SpinerLoading,
  ButtonClose,
} from "./Loader.css";

function Loader({
  children,
  loading,
  handleClose,
  isPrinting,
  tip,
  showTip,
  ...rest
}) {
  return (
    <div>
      {loading ? (
        <LoaderWrapper {...rest}>
          {isPrinting && (
            <ButtonClose className="btn btn-lg" onClick={() => handleClose()}>
              <i className="fas fa-times"></i>
            </ButtonClose>
          )}
          <DivLoading isPrinting={isPrinting}>
            <SpinerLoading className="spinner-border" role="status" />
            {showTip && <span>{tip}</span>}
          </DivLoading>
        </LoaderWrapper>
      ) : null}
      {children}
    </div>
  );
}

Loader.propTypes = {
  children: PropTypes.oneOfType([
    PropTypes.node,
    PropTypes.any,
    PropTypes.symbol,
  ]),
  loading: PropTypes.bool,
  tip: PropTypes.string,
  showTip: PropTypes.bool,
  className: PropTypes.string,
  handleClose: PropTypes.func,
  isPrinting: PropTypes.bool,
};

Loader.defaultProps = {
  loading: false,
  children: () => {},
  tip: "Carregando...",
  className: "",
  showTip: true,
  handleClose: () => {},
  isPrinting: false,
};

export default Loader;
