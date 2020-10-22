import React from "react";
import PropTypes from "prop-types";
import { LoaderWrapper, DivLoading, SpinerLoading, ButtonClose } from "./Loader.css";

function Loader({ children, loading, handleClose, isPrinting }) {
  return (
    <div>
      {loading ? (
        <LoaderWrapper>
         {
            isPrinting && (<ButtonClose
              className="btn btn-lg"
              onClick={() => handleClose()}
            >
              <i className="fas fa-times"></i>
            </ButtonClose>)
          }
          <DivLoading isPrinting={isPrinting}>
            <SpinerLoading className="spinner-border" role="status" />
            <span>Carregando...</span>
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
  ignorarTip: PropTypes.bool,
  className: PropTypes.string,
  handleClose: PropTypes.func,
  isPrinting: PropTypes.bool,
};

Loader.defaultProps = {
  loading: false,
  children: () => {},
  tip: "Carregando...",
  className: "",
  ignorarTip: false,
  handleClose: () => {},
  isPrinting: false,
};

export default Loader;
