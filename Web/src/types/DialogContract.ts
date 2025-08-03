import type { ContractEntity } from "@/entities/ContractEntity";

export type DialogContract = {
  value: {
    data: {
      model: ContractEntity;
      isNew: boolean;
      toDelete: boolean;
    };
    close: (result?: any) => void; // Opcional: para que puedas cerrar el diálogo
  };
};