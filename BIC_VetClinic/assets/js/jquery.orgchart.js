(function ($) {
    $.fn.orgChart = function (options) {
        var opts = $.extend({}, $.fn.orgChart.defaults, options);
        return new OrgChart($(this), opts);
    }

    $.fn.orgChart.defaults = {
        data: [{ id: 1, name: 'Root', parent: 0, level: 0 }],
        showControls: false,
        allowEdit: false,
        onAddNode: null,
        onDeleteNode: null,
        onClickNode: null,
        newNodeText: 'Add Child'
    };

    function OrgChart($container, opts) {

        var data = opts.data;
        var nodes = {};
        var rootNodes = [];
        this.opts = opts;
        this.$container = $container;
        var self = this;

        this.draw = function () {
            $container.empty().append(rootNodes[0].render(opts));
            $container.find('.node').click(function () {
            
                if (self.opts.onClickNode !== null) {
                    self.opts.onClickNode(nodes[$(this).attr('node-id')]);
                }
            });

            if (opts.allowEdit) {
                $container.find('.node h2').click(function (e) {
                    var thisId = $(this).parent().attr('node-id');
                    self.startEdit(thisId);
                    e.stopPropagation();
                });
            }

            // add "add button" listener
            $container.find('.org-button').click(function (e) {
                var thisId = $(this).parent().attr('node-id');
                if (self.opts.onAddNode !== null) {
                    self.opts.onAddNode(nodes[thisId]);
                }
                else {
                    self.newNode(thisId);
                }
                e.stopPropagation();
            });

            $container.find('.org-del-button').click(function (e) {
                var thisId = $(this).parent().attr('node-id');

                if (self.opts.onDeleteNode !== null) {
                    self.opts.onDeleteNode(nodes[thisId]);
                }
                else {
                    self.deleteNode(thisId);
                }
                e.stopPropagation();
            });
        }

        this.startEdit = function (id) {
            //var inputElement = $('<input class="org-input" type="text" readonly="readonly" value="' + nodes[id].data.name + '"/>');
            var inputElement = $('<input class="org-input" type="text" readonly="readonly" value="' + nodes[id].data.name + '"/>');
            $container.find('div[node-id=' + id + '] h2').replaceWith(nodes[id].data.name);
            var commitChange = function () {
                var h2Element = $('<div>' + nodes[id].data.name + '</div>');
                if (opts.allowEdit) {
                    h2Element.click(function () {
                        self.startEdit(id);
                    })
                }
                inputElement.replaceWith(h2Element);
            }
            inputElement.focus();
            inputElement.keyup(function (event) {
                if (event.which == 13) {
                    commitChange();
                }
                else {
                    nodes[id].data.name = inputElement.val();
                }
            });
            inputElement.blur(function (event) {
                commitChange();
            })
        }

        this.newNode = function (nextId, parentId, name, level, nextlvl, customer, levelDesc, nxtLvlDesc, Image) {
            //var nextId = Object.keys(nodes).length;
            //while(nextId in nodes){
            //    nextId++;
            //}
            var arr = [];

            if (typeof nodes[parentId] != "undefined") {
                if (nodes[parentId].children.length > 0) {
                    for (var i = 0; i < nodes[parentId].children.length; i++) {
                        arr.push(nodes[parentId].children[i].data.id);
                    }
                }
                if (arr.indexOf(nextId) == -1) {
                 
                    self.addNode({ id: nextId, name: name, parent: parentId, level: level, nextlvl: nextlvl, customer: customer, levelDesc: levelDesc, nxtLvlDesc: nxtLvlDesc, Image: Image });
                } else {
                    self.deleteNode(nextId);
                    self.addNode({ id: nextId, name: name, parent: parentId, level: level, nextlvl: nextlvl, customer: customer, levelDesc: levelDesc, nxtLvlDesc: nxtLvlDesc, Image: Image });
                }
                $(".divtooltip").tooltip();
            }
        }

        this.addNode = function (data) {
            var newNode = new Node(data);
            nodes[data.id] = newNode;
            nodes[data.parent].addChild(newNode);

            self.draw();
            self.startEdit(data.id);
        }

        this.deleteNode = function (id) {
            for (var i = 0; i < nodes[id].children.length; i++) {
                self.deleteNode(nodes[id].children[i].data.id);
            }
            nodes[nodes[id].data.parent].removeChild(id);
            delete nodes[id];
            self.draw();
        }

        this.getData = function () {
            var outData = [];
            for (var i in nodes) {
                outData.push(nodes[i].data);
            }
            return outData;
        }

        // constructor
        for (var i in data) {
            var node = new Node(data[i]);
            nodes[data[i].id] = node;
        }

        // generate parent child tree
        for (var i in nodes) {
            if (nodes[i].data.parent == 0) {
                rootNodes.push(nodes[i]);
            }
            else {
                nodes[nodes[i].data.parent].addChild(nodes[i]);
            }
        }

        // draw org chart
        $container.addClass('orgChart');
        self.draw();
    }

    function Node(data) {
        this.data = data;
        this.children = [];
        var self = this;

        this.addChild = function (childNode) {
            this.children.push(childNode);
        }

        this.removeChild = function (id) {

            for (var i = 0; i < self.children.length; i++) {
                if (self.children[i].data.id == id) {
                    self.children.splice(i, 1);
                    return;
                }
            }
        }

        this.render = function (opts) {
            var childLength = self.children.length,
                mainTable;

            mainTable = "<table id='charttable' cellpadding='0' cellspacing='0' border='0'>";
            var nodeColspan = childLength > 0 ? 2 * childLength : 2;
            mainTable += "<tr class='chartnodes'><td colspan='" + nodeColspan + "'>" + self.formatNode(opts) + "</td></tr>";

            if (childLength > 0) {
                var downLineTable = "<table cellpadding='0' cellspacing='0' border='0'><tr class='lines x'><td class='line left half'></td><td class='line right half'></td></table>";
                mainTable += "<tr  class='lines'><td colspan='" + childLength * 2 + "'>" + downLineTable + '</td></tr>';

                var linesCols = '';
                for (var i = 0; i < childLength; i++) {
                    if (childLength == 1) {
                        linesCols += "<td class='line left half'></td>";    // keep vertical lines aligned if there's only 1 child
                    }
                    else if (i == 0) {
                        linesCols += "<td class='line left'></td>";     // the first cell doesn't have a line in the top
                    }
                    else {
                        linesCols += "<td class='line left top'></td>";
                    }

                    if (childLength == 1) {
                        linesCols += "<td class='line right half'></td>";
                    }
                    else if (i == childLength - 1) {
                        linesCols += "<td class='line right'></td>";
                    }
                    else {
                        linesCols += "<td class='line right top'></td>";
                    }
                }
                mainTable += "<tr class='lines v'>" + linesCols + "</tr>";

                mainTable += "<tr>";
                for (var i in self.children) {
                    mainTable += "<td colspan='2' class='ClsLast'>" + self.children[i].render(opts) + "</td>";
                }
                mainTable += "</tr>";
            }
            mainTable += '</table>';
            return mainTable;
        }

        this.formatNode = function (opts) {
            var nameString = '', descString = ''; strempinfo = '';

            if (typeof data.name !== 'undefined') {
                // alert(JSON.stringify(this.data));
                nameString = '<div id=' + this.data.id + ' class="divtooltip" data-toggle="tooltip" data-placement="top" style=height:55px;  title="' + this.data.customer + '">' + self.data.name + " (" + self.data.levelDesc + ")" + '</div>';
            }
            if (typeof data.description !== 'undefined') {
                descString = '<p>' + self.data.description + '</p>';
            }

            //alert(JSON.stringify(this.data)); 

            strempinfo = "<div id='LoadOrg_" + this.data.id + "'><span class='red'><b>" + this.data.USERNAME + "</b></span></br><b>" + this.data.text + "</b></br>[" + this.data.FIELDVALUEDSEC + "]</div>";
            if (opts.showControls) {
                var buttonsHtml = '';

                if (this.data.nextlvl > 0) {

                } else {

                }
                buttonsHtml = "<div class='org-button divtooltip'>" + strempinfo + "</div>";

            }
            else {
                buttonsHtml = "<div class='org-button divtooltip'>" + strempinfo + "</div>";
            }

            return "<div class='node' node-lvlid='" + this.data.level + "' node-pid='" + this.data.parent + "' node-id='" + this.data.id + "' style='width:150px;height:100px;'>" + nameString + descString + buttonsHtml + "<div><input type='hidden' id='emp_" + this.data.id + "' value='" + this.data.id + "' /></div></div>";
        }
    }

})(jQuery);

