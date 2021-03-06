import React from "react";
import { Route, Redirect } from "react-router-dom";
import { actionCreators } from "../store/User";
import { useSelector, useDispatch } from "react-redux";

const AuthenticatedDashboardProfileRoute = ({ component: C, ...rest }) => {
  const user = useSelector((c) => c.user);
  const dispatch = useDispatch();
  return (
    <Route
      {...rest}
      render={(props) => {
        if (user.isAuthenticated) {
          if (user.permissoes) return <Route component={C} />;
        }
        dispatch(actionCreators.logout({}));
        return (
          <Redirect
            to={`/Login?redirect=${props.location.pathname}${props.location.search}`}
          />
        );
      }}
    />
  );
};

export default AuthenticatedDashboardProfileRoute;
