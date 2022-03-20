import{coin} from './coin'

export class Donation {
  public id:number;
  public isDeleting?:boolean

    constructor(
        public amount:number,
        public entityName: string,
        public entityType: string,
        public destiny: string,
        public coin: string,
        public exchangedRate: number,
        public conditions: string,
      ) {  }
}
