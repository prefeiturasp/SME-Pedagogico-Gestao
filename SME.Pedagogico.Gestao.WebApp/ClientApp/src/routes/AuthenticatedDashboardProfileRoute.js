import React from "react";
import { Route, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import Dashboard from "../components/navigation/Dashboard";
import { ROLES_ENUM } from "../Enums";

const AuthenticatedDashboardProfileRoute = ({ component: C, user, ...rest }) => {
  return (
    <Route
      {...rest}
      render={props => {

        debugger;
        if (
          user.isAuthenticated &&
          user.activeRole.roleName !== ROLES_ENUM.ADM_DRE
        ) {
          return (
            <Dashboard>
              <C />
            </Dashboard>
          );
        } else if (
          user.isAuthenticated &&
          user.activeRole.roleName === ROLES_ENUM.ADM_DRE
        ) {
          return <Redirect to={`/Relatorios/Sondagem`} />;
        } else if (!user.isAuthenticated)  {
          return (
            <Redirect
              to={`/Login?redirect=${props.location.pathname}${
                props.location.search
              }`}
            />
          );
        }
      }}
    />
  );
};

export default connect(state => ({ user: state.user }))(
  AuthenticatedDashboardProfileRoute
);
