import { ProductView } from './productview';

export class ProductPagedList{
id: string;
  netToPay: number;
  grossToPay: number;
  totalItems: number;
  currentPage: number;
  pageSize: number;
  totalPages: number;
  startIndex: number;
  endIndex: number;
  items: ProductView[];
}