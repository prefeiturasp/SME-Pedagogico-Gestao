import { Modal } from "antd";

export const showModalError = ({
  title = "Erro",
  okText = "Fechar",
  content = "",
}) => {
  return Modal.error({
    centered: true,
    title,
    okText,
    content,
  });
};

export const showModalSuccess = ({
  title = "Sucesso",
  okText = "Fechar",
  content = "",
}) => {
  return Modal.success({
    centered: true,
    title,
    okText,
    content,
  });
};

export const showModalConfirm = ({
  title = "Atenção",
  okText = "Sim",
  cancelText = "Não",
  content = "",
  onOk,
  onCancel,
}) => {
  return Modal.confirm({
    centered: true,
    title,
    okText,
    cancelText,
    content,
    onOk,
    onCancel,
  });
};

export const showModalConfirmAsync = ({
    title = "Atenção",
    okText = "Sim",
    cancelText = "Não",
    content = "",
    onOk,
    onCancel,
}) => {
    return new Promise((resolve, reject) => {
        Modal.confirm({
            centered: true,
            title,
            okText,
            cancelText,
            content,
            onOk: () => {
                if (onOk) {
                    onOk();
                }
                resolve(true); 
            },
            onCancel: () => {
                if (onCancel) {
                    onCancel();
                }
                resolve(false);
            },
        });
    });
};
