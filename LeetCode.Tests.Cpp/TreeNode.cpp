#include "pch.h"
#include "TreeNode.h"

// From level order vector
TreeNode* createBinaryTree(const std::vector<int>& values) {
    if (values.empty() || values[0] == -1) return nullptr;

    TreeNode* root = new TreeNode(values[0]);
    std::queue<TreeNode*> q;
    q.push(root);

    size_t i = 1;
    while (i < values.size()) {
        TreeNode* node = q.front();
        q.pop();

        if (values[i] != -1) {
            node->left = new TreeNode(values[i]);
            q.push(node->left);
        }
        i++;

        if (i < values.size() && values[i] != -1) {
            node->right = new TreeNode(values[i]);
            q.push(node->right);
        }
        i++;
    }

    return root;
}

// To level order vector
std::vector<int> binaryTreeToVector(TreeNode* root) {
    std::vector<int> result;
    if (!root) return result;

    std::queue<TreeNode*> q;
    q.push(root);

    while (!q.empty()) {
        TreeNode* node = q.front();
        q.pop();
        if (node) {
            result.push_back(node->val);
            q.push(node->left);
            q.push(node->right);
        }
        else {
            result.push_back(-1);
        }
    }

    return result;
}

void deleteBinaryTree(TreeNode* root) {
    if (!root) return;
    deleteBinaryTree(root->left);
    deleteBinaryTree(root->right);
    delete root;
}

int maxDepth(TreeNode* root) {
    if (!root) return 0;
    return 1 + std::max(maxDepth(root->left), maxDepth(root->right));
}

bool leafSimilar(TreeNode* root1, TreeNode* root2) {
    std::vector<int> endLeaves;
    std::vector<int> endLeaves2;
    collectLeafNodes(root1, endLeaves);
    collectLeafNodes(root2, endLeaves2);
    return endLeaves == endLeaves2;
}

std::vector<int> collectLeafNodes(TreeNode* head, std::vector<int>& endLeaves) {
    if (!head) return endLeaves;
    if (!head->left && !head->right) {
        endLeaves.push_back(head->val);
        return endLeaves;
    }
    collectLeafNodes(head->left, endLeaves);
    collectLeafNodes(head->right, endLeaves);
    return endLeaves;
}