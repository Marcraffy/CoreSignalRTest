import { CoreSignalRTestTemplatePage } from './app.po';

describe('CoreSignalRTest App', function() {
  let page: CoreSignalRTestTemplatePage;

  beforeEach(() => {
    page = new CoreSignalRTestTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
