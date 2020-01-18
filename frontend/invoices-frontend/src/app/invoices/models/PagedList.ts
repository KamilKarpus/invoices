import { InvoicesView } from './InvoicesShortView';

export class PagedList {
        totalItems: number;
        currentPage: number;
        pageSize: number;
        totalPages: number;
        startIndex: number;
        endIndex: number;
        items: InvoicesView[];
    }

