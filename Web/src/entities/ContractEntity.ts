export class ContractEntity {
      id: number = 0;
      author: string = '';
      name: string = '';
      description: string = '';
      createdDate: string = Date.toString();
      updatedDate: string = Date.toString();
      get descriptionShort(): string { 
        return (this.description.length > 20) ? this.description.substring(0,17)+'...' : this.description; 
      }
    }