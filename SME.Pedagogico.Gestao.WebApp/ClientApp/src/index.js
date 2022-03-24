import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import "@fortawesome/fontawesome-free/css/all.min.css";
import "@fortawesome/fontawesome-free/js/all.min.js";
import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { createBrowserHistory } from "history";
import { BrowserRouter } from "react-router-dom";
import configureStore from "./store/configureStore";
import { PersistGate } from "redux-persist/integration/react";
import App from "./App";
import registerServiceWorker from "./registerServiceWorker";

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const history = createBrowserHistory({ basename: baseUrl });

// Get the application-wide store instance, prepopulating with state from the server where available.
const initialState = window.initialReduxState;
export const { store, persistor } = configureStore(history, initialState);

const rootElement = document.getElementById("root");

ReactDOM.render(
  <Provider store={store}>
    <PersistGate loading={null} persistor={persistor}>
      <BrowserRouter basename={baseUrl}>
        <App />
      </BrowserRouter>
    </PersistGate>
  </Provider>,
  rootElement
);

registerServiceWorker();
