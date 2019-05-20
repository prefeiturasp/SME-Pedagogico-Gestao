import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import createSagaMiddleware from 'redux-saga';
import * as User from './User';
import UserSaga from '../sagas/User';
import FrequencySaga from '../sagas/Frequency';
import * as LeftMenu from './LeftMenu';
import * as Calendar from './Calendar';
import * as Frequency from './Frequency';
import { persistStore, persistReducer } from 'redux-persist';
import storage from 'redux-persist/lib/storage'; // defaults to localStorage for web and AsyncStorage for react-native
import logger from 'redux-logger';

export default function configureStore(history, initialState) {
    const reducers = {
        //Inserir reducers necessários
        //Ex.:
        //counter: Counter.reducer,
        user: User.reducer,
        leftMenu: LeftMenu.reducer,
        calendar: Calendar.reducer,
        frequency: Frequency.reducer,
    };

    const reduxSaga = createSagaMiddleware();

    const persistConfig = {
        key: 'root',
        storage
    };

    const middleware = [
        //Inserir middlewares necessários
        //Ex.:
        //thunk,
        reduxSaga,
    ];

    // In development, use the browser's Redux dev tools extension if installed
    const enhancers = [];
    const isDevelopment = process.env.NODE_ENV === 'development';
    if (isDevelopment && typeof window !== 'undefined' && window.__REDUX_DEVTOOLS_EXTENSION__) {
        enhancers.push(window.__REDUX_DEVTOOLS_EXTENSION__());
    }

    // Redux-logger on development
    if (isDevelopment)
        middleware.push(logger);

    const rootReducer = combineReducers({
        ...reducers
    });

    const persistedReducer = persistReducer(persistConfig, rootReducer);

    const store = createStore(
        persistedReducer,
        initialState,
        compose(applyMiddleware(...middleware), ...enhancers)
    );

    const persistor = persistStore(store);

    reduxSaga.run(UserSaga);
    reduxSaga.run(FrequencySaga);

    return ({ store, persistor });
}